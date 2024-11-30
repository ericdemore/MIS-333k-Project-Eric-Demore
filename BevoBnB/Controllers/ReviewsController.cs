using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BevoBnB.DAL;
using BevoBnB.Models;
using BevoBnB.ViewModels;

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
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            // Fetch the user's reviews
            var reviews = await _context.Reviews
                .Include(r => r.Property)
                .Where(r => r.User.Id == user.Id)
                .ToListAsync();

            return View(reviews); // Ensure this points to Views/Reviews/Index.cshtml
        }


        // GET: Reviews/Create
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            // Fetch properties the customer has reserved and not reviewed
            var reservedProperties = await _context.Reservations
                .Include(r => r.Property)
                .Where(r => r.User.Id == user.Id &&
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
                TempData["Message"] = "You have no eligible properties to review.";
                return RedirectToAction("Index");
            }

            // Prepare the ViewModel
            var viewModel = new ReviewCreateViewModel
            {
                PropertyOptions = reservedProperties
            };

            return View(viewModel); // Ensure this points to Views/Reviews/Create.cshtml
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(ReviewCreateViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            // Validate the property and ensure eligibility for review
            var property = await _context.Properties
                .FirstOrDefaultAsync(p => p.PropertyID == model.PropertyID &&
                                          _context.Reservations.Any(r => r.Property.PropertyID == p.PropertyID && r.User.Id == user.Id) &&
                                          !_context.Reviews.Any(review => review.Property.PropertyID == p.PropertyID && review.User.Id == user.Id));

            if (property == null)
            {
                ModelState.AddModelError("", "Invalid property selection. You cannot review this property.");
                model.PropertyOptions = await _context.Reservations
                    .Include(r => r.Property)
                    .Where(r => r.User.Id == user.Id &&
                                !_context.Reviews.Any(review => review.Property.PropertyID == r.Property.PropertyID && review.User.Id == user.Id))
                    .Select(r => new SelectListItem
                    {
                        Value = r.Property.PropertyID.ToString(),
                        Text = $"Property #{r.Property.PropertyNumber} - {r.Property.StreetAddress}, {r.Property.City}"
                    })
                    .Distinct()
                    .ToListAsync();

                return View("~/Views/Reviews/Create.cshtml", model);
            }

            // Create and save the review
            var review = new Review
            {
                Property = property,
                User = user,
                Rating = model.Rating,
                ReviewText = model.ReviewText
            };

            if (!ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                // Redirect to the Details page with the ReviewID
                return RedirectToAction("Details", new { id = review.ReviewID });
            }

            // Re-populate ViewModel if ModelState is invalid
            model.PropertyOptions = await _context.Reservations
                .Include(r => r.Property)
                .Where(r => r.User.Id == user.Id &&
                            !_context.Reviews.Any(review => review.Property.PropertyID == r.Property.PropertyID && review.User.Id == user.Id))
                .Select(r => new SelectListItem
                {
                    Value = r.Property.PropertyID.ToString(),
                    Text = $"Property #{r.Property.PropertyNumber} - {r.Property.StreetAddress}, {r.Property.City}"
                })
                .Distinct()
                .ToListAsync();

            return View("~/Views/Reviews/Create.cshtml", model);
        }


        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            // Fetch the review with the associated property
            var review = await _context.Reviews
                .Include(r => r.Property)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            return View(review); // Ensure this view is located at Views/Reviews/Details.cshtml
        }



    }
}
