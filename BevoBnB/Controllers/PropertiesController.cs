using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BevoBnB.DAL;
using BevoBnB.Models;
using BevoBnB.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Authorization;

namespace BevoBnB.Controllers
{
    [Authorize]
    public class PropertiesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PropertiesController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Properties
        [AllowAnonymous]
        public IActionResult Index()
        {
            var approvedPropertiesQuery = _context.Properties
                .Include(p => p.User)
                .Include(p => p.Reviews)
                .Include(p => p.Category)
                .Include(p => p.Reservations)
                .Where(p => p.PropertyStatus == PropertyStatus.Approved &&
                            p.PropertyStatus != PropertyStatus.Inactive &&
                            p.PropertyStatus != PropertyStatus.Unapproved);

            List<Property> properties = approvedPropertiesQuery.ToList();

            ViewBag.AllCategories = GetAllCategories();
            ViewBag.AllProperties = approvedPropertiesQuery.Count();
            ViewBag.SelectedProperties = properties.Count;

            return View(properties);
        }

        [AllowAnonymous]
        public IActionResult DisplaySearchResults(PropertySearchViewModel psvm)
        {
            var query = _context.Properties
                .Include(p => p.User)
                .Include(p => p.Reviews)
                .Include(p => p.Category)
                .Include(p => p.Reservations)
                .Where(p => p.PropertyStatus == PropertyStatus.Approved &&
                            p.PropertyStatus != PropertyStatus.Inactive &&
                            p.PropertyStatus != PropertyStatus.Unapproved);

            var copyQuery = query;

            if (!string.IsNullOrEmpty(psvm.City))
            {
                query = query.Where(p => p.City.Contains(psvm.City));
            }

            if (psvm.State != null)
            {
                query = query.Where(p => p.State == psvm.State);
            }

            if (psvm.GuestRating != null)
            {
                if (psvm.GuestRatingRange == null || psvm.GuestRatingRange == PSVMRange.GreaterThan)
                {
                    query = query.Where(p => p.AverageRating >= psvm.GuestRating);
                }
                else if (psvm.GuestRatingRange == PSVMRange.LessThan)
                {
                    query = query.Where(p => p.AverageRating <= psvm.GuestRating);
                }
            }

            if (psvm.MaxGuests != null)
            {
                if (psvm.MaxGuestsRange == null || psvm.MaxGuestsRange == PSVMRange.GreaterThan)
                {
                    query = query.Where(p => p.GuestsAllowed >= psvm.MaxGuests);
                }
                else if (psvm.MaxGuestsRange == PSVMRange.LessThan)
                {
                    query = query.Where(p => p.GuestsAllowed <= psvm.MaxGuests);
                }
            }

            if (psvm.Bedrooms != null)
            {
                query = query.Where(p => p.Bedrooms == psvm.Bedrooms);
            }

            if (psvm.Bathrooms != null)
            {
                query = query.Where(p => p.Bathrooms == psvm.Bathrooms);
            }

            if (psvm.PetsAllowed != null)
            {
                query = query.Where(p => p.PetsAllowed == psvm.PetsAllowed);
            }

            if (psvm.FreeParking != null)
            {
                query = query.Where(p => p.FreeParking == psvm.FreeParking);
            }

            if (psvm.CheckIn != null && psvm.CheckOut != null)
            {
                query = query.Where(p => !_context.Reservations.Any(r =>
                    r.Property.PropertyID == p.PropertyID &&
                    r.ReservationStatus != ReservationStatus.Cancelled && // Ignore cancelled reservations
                    r.CheckIn < psvm.CheckOut && // Overlapping reservation logic
                    r.CheckOut > psvm.CheckIn));
            }

            if (psvm.Category != null)
            {
                query = query.Where(p => p.CategoryId == psvm.Category);
            }

            if (psvm.MinWeekdayPricing != null)
            {
                query = query.Where(p => p.WeekdayPricing >= psvm.MinWeekdayPricing);
            }

            if (psvm.MaxWeekdayPricing != null)
            {
                query = query.Where(p => p.WeekdayPricing <= psvm.MaxWeekdayPricing);
            }

            if (psvm.MinWeekendPricing != null)
            {
                query = query.Where(p => p.WeekendPricing >= psvm.MinWeekendPricing);
            }

            if (psvm.MaxWeekendPricing != null)
            {
                query = query.Where(p => p.WeekendPricing <= psvm.MaxWeekendPricing);
            }

            List<Property> SelectedProperties = query.ToList();

            ViewBag.AllProperties = copyQuery.Count();
            ViewBag.SelectedProperties = SelectedProperties.Count;
            ViewBag.AllCategories = GetAllCategories();

            return View("Index", SelectedProperties);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Unapproved()
        {
            var unapprovedPropertiesQuery = _context.Properties
                .Include(p => p.Category)
                .Include(p => p.Reviews)
                .Include(p => p.User)
                .Where(p => p.PropertyStatus == PropertyStatus.Unapproved)
                .OrderBy(p => p.City)
                .ThenBy(p => p.State)
                .ThenBy(p => p.PropertyID);

            List<Property> unapprovedProperties = await unapprovedPropertiesQuery.ToListAsync();

            ViewBag.AllCategories = GetAllCategories();
            ViewBag.TotalItems = _context.Properties.Count();
            ViewBag.CurrentItems = unapprovedProperties.Count;

            return View("Index", unapprovedProperties);
        }

        public async Task<IActionResult> Inactive()
        {
            var inactivePropertiesQuery = _context.Properties
                .Include(p => p.Category)
                .Include(p => p.Reviews)
                .Include(p => p.User)
                .Where(p => p.PropertyStatus == PropertyStatus.Inactive)
                .OrderBy(p => p.City)
                .ThenBy(p => p.State)
                .ThenBy(p => p.PropertyID);

            List<Property> inactiveProperties = await inactivePropertiesQuery.ToListAsync();

            ViewBag.AllCategories = GetAllCategories();
            ViewBag.TotalItems = _context.Properties.Count();
            ViewBag.CurrentItems = inactiveProperties.Count;

            return View("Index", inactiveProperties);
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                // Display a generic error message for missing property ID
                ViewBag.ErrorMessage = "Property ID was not provided.";
                return View("Error");
            }

            // Fetch property details, including reviews
            var property = await _context.Properties
                .Include(p => p.Reviews) // Include the Reviews navigation property
                .FirstOrDefaultAsync(m => m.PropertyID == id);

            if (property == null)
            {
                // Display a user-friendly error if the property doesn't exist
                ViewBag.ErrorMessage = $"Property with ID {id} was not found.";
                return View("Error");
            }

            // Restrict access to unapproved properties for customers
            if (property.PropertyStatus != PropertyStatus.Approved && User.IsInRole("Customer"))
            {
                ViewBag.ErrorMessage = "You are not authorized to view this property.";
                return View("Error");
            }

            // Calculate average rating for the property
            ViewBag.AvgRating = property.Reviews != null && property.Reviews.Any()
                ? property.Reviews.Average(r => r.Rating).ToString("0.0")
                : "No Ratings Yet";

            // Return the property details view
            return View(property);
        }


        // GET: Properties/Create
        [HttpGet]
        [Authorize(Roles = "Host")]
        public IActionResult Create()
        {
            if (User.IsInRole("Host") == false)
            {
                return View("Error", new string[] { "You are not authorized to create properties." });
            }

            // Fetch categories from the database and populate the dropdown
            ViewBag.AllCategories = GetAllCategoriesSelectList();

            Property newProperty = new Property()
            {
                PropertyNumber = Utilities.GenerateNextPropertyNumber.GetNextPropertyNumber(_context),
                PropertyStatus = PropertyStatus.Unapproved,
                UnavailableDates = new List<DateTime>()
            };

            return View(newProperty);
        }

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Create(Property property)
        {
            // Restrict access to hosts
            if (User.IsInRole("Host") == false)
            {
                return View("Error");
            }

            
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            property.User = user;
            property.PropertyNumber = Utilities.GenerateNextPropertyNumber.GetNextPropertyNumber(_context);
            property.PropertyStatus = PropertyStatus.Unapproved;
            property.UnavailableDates = new List<DateTime>();

            _context.Add(property);
            await _context.SaveChangesAsync();

            return View("Details", property);
        }

        [Authorize(Roles = "Host")]
        public async Task<IActionResult> MyProperties()
        {
            List<Property> myProperties;

            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            myProperties = _context.Properties
                .Include(p => p.User)
                .Where(p => p.User.Email == user.Email)
                .ToList();

            return View("Index", myProperties);
        }

        [Authorize(Roles = "Admin, Host")]
        public async Task<IActionResult> ApproveProperty(int propertyID)
        {
            if (propertyID == null)
            {
                return View("Error", new string[] { "You did not provide a valid ID." });
            }

            Property property = await _context.Properties
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.PropertyID == propertyID);

            if (property == null)
            {
                return View("Error", new string[] { "No property was found with the provided ID." });
            }

            if (User.IsInRole("Admin"))
            {
                property.PropertyStatus = PropertyStatus.Approved;
            }
            else if (User.IsInRole("Host"))
            {
                if (property.User.Email != User.Identity.Name)
                {
                    return View("Error", new string[] { "You can only approve properties that belong to you." });
                }
                if (property.PropertyStatus == PropertyStatus.Inactive)
                {
                    property.PropertyStatus = PropertyStatus.Approved;
                }
                else
                {
                    return View("Error", new string[] { "Only inactive properties can be re-approved." });
                }
            }

            _context.Properties.Update(property);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = property.PropertyID });
        }

        //deactivate property
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> DeactiveProperty(int propertyID)
        {

            if (propertyID == null)
            {
                return View("Error", new string[] { "You did not provide an ID." });
            }

            Property property = await _context.Properties.FindAsync(propertyID);
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (property == null)
            {
                return View("Error", new String[] { "No property was found." });
            }

            if (property.User.Email != User.Identity.Name)
            {
                return View("Error", new String[] { "This property does not belong to you." });
            }

            // Update the property status to approved
            property.PropertyStatus = PropertyStatus.Inactive;

            _context.Properties.Update(property);
            await _context.SaveChangesAsync();

            // Redirect to the Details view of the approved property
            return RedirectToAction("Details", new { id = property.PropertyID });
        }


        //edit
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @property = await _context.Properties.FindAsync(id);
        //    if (@property == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(@property);
        //}

        //// POST: Properties/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PropertyID,PropertyNumber,StreetAddress,City,State,ZipCode,Bedrooms,Bathrooms,GuestsAllowed,PetsAllowed,FreeParking,WeekdayPricing,WeekendPricing,CleaningFee,DiscountRate,MinNightsforDiscount,UnavailableDates,PropertyStatus")] Property @property)
        //{
        //    if (id != @property.PropertyID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(@property);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PropertyExists(@property.PropertyID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(@property);
        //}

        [HttpGet]
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include the property owner information
            var property = await _context.Properties
                .Include(p => p.User) // Include the User navigation property
                .FirstOrDefaultAsync(p => p.PropertyID == id);

            if (property == null)
            {
                return NotFound();
            }

            // Ensure the logged-in user is the owner of the property
            var loggedInUserId = _userManager.GetUserId(User);
            if (property.User.Id != loggedInUserId)
            {
                return Forbid(); // Return 403 Forbidden if they don't own the property
            }

            return View(property);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Edit(int id, [Bind("WeekdayPricing,WeekendPricing,CleaningFee,DiscountRate,MinNightsforDiscount")] Property updatedProperty)
        {
            // Fetch the original property from the database
            var property = await _context.Properties
                .Include(p => p.User) // Include the User navigation property
                .FirstOrDefaultAsync(p => p.PropertyID == id);

            if (property == null)
            {
                return NotFound();
            }

            // Ensure the logged-in user is the owner of the property
            var loggedInUserId = _userManager.GetUserId(User);
            if (property.User.Id != loggedInUserId)
            {
                return Forbid(); // Return 403 Forbidden if they don't own the property
            }

            // Update only the pricing and discount-related fields
            property.WeekdayPricing = updatedProperty.WeekdayPricing;
            property.WeekendPricing = updatedProperty.WeekendPricing;
            property.CleaningFee = updatedProperty.CleaningFee;
            property.DiscountRate = updatedProperty.DiscountRate;
            property.MinNightsforDiscount = updatedProperty.MinNightsforDiscount;

            try
            {
                _context.Update(property);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(property.PropertyID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties
                .FirstOrDefaultAsync(m => m.PropertyID == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @property = await _context.Properties.FindAsync(id);
            if (@property != null)
            {
                _context.Properties.Remove(@property);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.PropertyID == id);
        }

        // GetAllCategoriesSelectList Method
        private SelectList GetAllCategoriesSelectList()
        {
            // Get the list of categories from the database
            List<Category> categoryList = _context.Categories.ToList();

            // Add a dummy entry so the user can select a default category (like "Select a Category")
            Category selectNone = new Category() { CategoryID = 0, CategoryName = "Select a Category" };
            categoryList.Insert(0, selectNone); // Insert it at the start of the list

            // Convert the list to a SelectList
            SelectList categorySelectList = new SelectList(categoryList.OrderBy(c => c.CategoryID), "CategoryID", "CategoryName");

            // Return the SelectList
            return categorySelectList;
        }

        private bool IsReservationConflict(Reservation reservation)
        {
            if (reservation.Property == null)
            {
                return false;
            }

            // Check for date conflicts with existing reservations
            var existingReservations = _context.Reservations
                .Where(r => r.Property.PropertyID == reservation.Property.PropertyID &&
                            r.ReservationStatus != ReservationStatus.Cancelled &&
                            r.ReservationStatus != ReservationStatus.Pending)
                .ToList();

            foreach (var existingReservation in existingReservations)
            {
                if (reservation.CheckIn < existingReservation.CheckOut && reservation.CheckOut > existingReservation.CheckIn)
                {
                    if (reservation.CheckOut == existingReservation.CheckIn || reservation.CheckIn == existingReservation.CheckOut)
                    {
                        continue;
                    }

                    return true;
                }
            }

            // Check if any unavailable dates fall within the reservation period
            if (reservation.Property.UnavailableDates != null && reservation.Property.UnavailableDates.Any())
            {
                foreach (var unavailableDate in reservation.Property.UnavailableDates)
                {
                    if (unavailableDate >= reservation.CheckIn && unavailableDate <= reservation.CheckOut)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private SelectList GetAllCategories()
        {
            var categories = _context.Categories
                .Select(c => new { c.CategoryID, c.CategoryName })
                .ToList();

            return new SelectList(categories, "CategoryID", "CategoryName");
        }


    }
}
