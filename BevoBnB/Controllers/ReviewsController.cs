using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BevoBnB.DAL;
using BevoBnB.Models;
using BevoBnB.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BevoBnB.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReviewsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reviews/Index
        [Authorize(Roles = "Customer,Host,Admin")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account"); //QUESTION: this should probably lead to an error view with a detailed messaged?
            }

            //NOTE: you could've used if (use.isinrole"")
            if (await _userManager.IsInRoleAsync(user, "Host"))
            {
                // Host: Show reviews for properties owned by the host
                var hostReviews = await _context.Reviews
                    .Include(r => r.Property)
                    .Where(r => r.Property.User.Id == user.Id)
                    .OrderBy(r => r.DisputeStatus == DisputeStatus.NoDispute ? 0 : 1) //QUESTION: what is this doing??
                    .ToListAsync();

                return View(hostReviews);
            }
            else if (await _userManager.IsInRoleAsync(user, "Customer"))
            {
                // Customer: Show reviews written by the logged-in customer
                var customerReviews = await _context.Reviews
                    .Include(r => r.Property)
                    .Where(r => r.User.Id == user.Id)
                    .ToListAsync();

                return View(customerReviews);
            }
            else if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                // Admin: Show all reviews
                var allReviews = await _context.Reviews
                    .Include(r => r.Property)
                    .Include(r => r.User)
                    .ToListAsync();

                return View(allReviews);
            }

            //QUESTION: what is forbid? return to an error view with a detailed message
            return Forbid(); // Deny access for unauthorized roles
        }

        // GET: Reviews/Create
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account"); //again send them to an error view with a detailed error on why it failed
            }

            // Fetch properties the customer has reserved and not reviewed, and check reservation date
            var reservedProperties = await _context.Reservations
                .Include(r => r.Property)
                .Where(r => r.User.Id == user.Id &&
                            r.CheckIn <= DateTime.Now && // Ensure reservation date has passed
                            !_context.Reviews.Any(review => review.Property.PropertyID == r.Property.PropertyID && review.User.Id == user.Id))
                .Select(r => new SelectListItem
                {
                    Value = r.Property.PropertyID.ToString(),
                    Text = $"Property #{r.Property.PropertyNumber} - {r.Property.StreetAddress}, {r.Property.City}"
                })
                .Distinct()
                .ToListAsync();

            if (!reservedProperties.Any())
            {
                TempData["Message"] = "You have no eligible properties to review at this time.";
                return RedirectToAction("Index");
            }

            // Prepare the ViewModel
            var viewModel = new ReviewCreateViewModel
            {
                PropertyOptions = reservedProperties
            };

            return View(viewModel); // Ensure this points to Views/Reviews/Create.cshtml
        }


        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(int PropertyID, int Rating, string? ReviewText)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            // Validate the property and ensure the reservation date has been reached
            var property = await _context.Properties
                .FirstOrDefaultAsync(p => p.PropertyID == PropertyID &&
                                          _context.Reservations.Any(r =>
                                              r.Property.PropertyID == p.PropertyID &&
                                              r.User.Id == user.Id &&
                                              r.CheckIn <= DateTime.Now) && // Ensure reservation date has passed
                                          !_context.Reviews.Any(review => review.Property.PropertyID == p.PropertyID && review.User.Id == user.Id));

            if (property == null)
            {
                ModelState.AddModelError("", "Invalid property selection or reservation date has not been reached.");
                TempData["Message"] = "You cannot leave a review for this property yet.";
                return RedirectToAction("Index");
            }

            // Create and save the review
            var review = new Review
            {
                Property = property,
                User = user,
                Rating = Rating,
                ReviewText = ReviewText,
                DisputeStatus = DisputeStatus.NoDispute // Default status
            };

            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            TempData["Message"] = "There was an error creating your review.";
            return RedirectToAction("Index");
        }

        // GET: Reviews/Edit/{id}
        [Authorize(Roles = "Customer,Host")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var review = await _context.Reviews
                .Include(r => r.Property)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review == null)
            {
                return View("Error", new string[] { "Review Not Found" });
            }

            if (User.IsInRole("Host"))
            {
                // Check if the host owns the property related to the review
                var hostProperties = await _context.Properties
                    .Where(p => p.User.Id == user.Id)
                    .Select(p => p.PropertyID)
                    .ToListAsync();

                if (!hostProperties.Contains(review.Property.PropertyID))
                {
                    return View("Error", new string[] { "You don't have access to this review." });
                }
            }

            if (User.IsInRole("Customer") && review.User.Id != user.Id)
            {
                return View("Error", new string[] { "You are not the rightful owner of this review." });
            }

            // Proceed to the edit view if all checks pass
            return View(review);
        }



        // POST: Reviews/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer,Host")]
        public async Task<IActionResult> Edit(int id, Review model)
        {
            var user = await _userManager.GetUserAsync(User);



            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var review = await _context.Reviews
                .Include(r => r.Property)
                .Include(r =>r.User)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review == null)
            {
                return View("Error", new string[] { "Review Not Found" });
            }

            // Ensure that only the host or customer can edit the review
            if (User.IsInRole("Host") && review.Property.User.Id != user.Id)
            {
                return View("Error", new string[] { "You are not authorize to edit reviews" });
            }

            if (User.IsInRole("Customer") && review.User.Id != user.Id)
            {
                return View("Error", new string[] { "You are not the right user" });
            }

            if (await _userManager.IsInRoleAsync(user, "Host"))
            {
                // Host can update HostComments
                review.HostComments = model.HostComments;

                // If host added comments and the dispute status is NoDispute, change it to Disputed
                if (!string.IsNullOrEmpty(review.HostComments) && review.DisputeStatus == DisputeStatus.NoDispute)
                {
                    review.DisputeStatus = DisputeStatus.Disputed;
                }
            }
            else if (await _userManager.IsInRoleAsync(user, "Customer"))
            {
                // Customer can update Rating and ReviewText
                review.Rating = model.Rating;
                review.ReviewText = model.ReviewText;
            }

            // Save changes to the review
            if (!ModelState.IsValid)
            {
                _context.Reviews.Update(review);
                await _context.SaveChangesAsync();

                TempData["Message"] = await _userManager.IsInRoleAsync(user, "Host")
                    ? "Dispute submitted."
                    : "Review updated.";
                return RedirectToAction("Index");
            }

            return View(review);
        }


        // GET: Reviews/Details/{id}
        [Authorize(Roles = "Admin,Host")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Property)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            // For hosts, ensure they can only view details of reviews for their properties
            if (User.IsInRole("Host"))
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null || review.Property.User.Id != user.Id)
                {
                    return Forbid();
                }
            }

            return View(review);
        }


        //Change Dispute Status
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeDisputeStatus(int reviewId, string newStatus)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.ReviewID == reviewId);

            if (review == null)
            {
                return NotFound();
            }

            // Check if the current DisputeStatus is NoDispute before allowing the admin to update
            if (review.DisputeStatus == DisputeStatus.NoDispute)
            {
                TempData["Message"] = "You cannot update the dispute status as it is currently 'No Dispute'. Please ensure the review is disputed first.";
                return RedirectToAction(nameof(Index));  // Redirect back to the review index page
            }

            // Update the DisputeStatus based on the string value
            if (Enum.TryParse(newStatus, out DisputeStatus parsedStatus))
            {
                review.DisputeStatus = parsedStatus;
                _context.Reviews.Update(review);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Dispute status updated successfully.";
            }
            else
            {
                TempData["Message"] = "Invalid dispute status.";
            }

            return RedirectToAction(nameof(Index));  // Redirect back to the review index page
        }


        //submit dispute
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> SubmitDispute(int id, string hostComments)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var review = await _context.Reviews
                .Include(r => r.Property)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            // Ensure the host owns the property
            if (review.Property.User.Id != user.Id)
            {
                return Forbid();
            }

            // Update the HostComments and check if the dispute status is NoDispute
            review.HostComments = hostComments;

            // If host added comments and the dispute status is NoDispute, change it to Disputed
            if (!string.IsNullOrEmpty(review.HostComments) && review.DisputeStatus == DisputeStatus.NoDispute)
            {
                review.DisputeStatus = DisputeStatus.Disputed;
            }

            // Save the review with updated HostComments and DisputeStatus
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            // After submitting the dispute, redirect back to the review index page
            TempData["Message"] = "The review has been disputed and is awaiting admin review.";
            return RedirectToAction("Index");
        }


        //Resolve Dispute
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ResolveDispute(int reviewId, bool isAccepted)
        {
            var review = await _context.Reviews
                .Include(r => r.Property)
                .FirstOrDefaultAsync(r => r.ReviewID == reviewId);

            if (review == null)
            {
                return NotFound();
            }

            if (isAccepted)
            {
                // Admin accepts the dispute - mark as ValidDispute and remove the review
                review.DisputeStatus = DisputeStatus.ValidDispute;
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                TempData["Message"] = "The dispute has been accepted, and the review has been removed.";
            }
            else
            {
                // Admin rejects the dispute - mark as InvalidDispute and keep the review
                review.DisputeStatus = DisputeStatus.InvalidDispute;
                _context.Reviews.Update(review);
                await _context.SaveChangesAsync();
                TempData["Message"] = "The dispute has been rejected, and the review is now valid.";
            }

            return RedirectToAction("Index");
        }

        //Dispute Review
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> DisputeReview(int reviewId)
        {
            // Find the review by ID
            var review = await _context.Reviews
                .Include(r => r.Property)
                .FirstOrDefaultAsync(r => r.ReviewID == reviewId);

            // If the review is not found
            if (review == null)
            {
                return View("Error", new string[] { "The review does not exist." });
            }

            // Check if the review has already been disputed
            if (review.DisputeStatus == DisputeStatus.Disputed ||
                review.DisputeStatus == DisputeStatus.InvalidDispute ||
                review.DisputeStatus == DisputeStatus.ValidDispute)
            {
                // Send a clear error message to the error view
                return View("Error", new string[] { "You have already disputed this review." });
            }

            // Mark the review as disputed
            review.DisputeStatus = DisputeStatus.Disputed;

            // Save the changes to the database
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            // Redirect back to the property details page
            return RedirectToAction("Details", new { id = review.Property.PropertyID });
        }


    }
}
