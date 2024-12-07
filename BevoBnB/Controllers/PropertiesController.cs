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
        // this allows a user to view all active properties. will return a clean active properties query and viewbags for the counts.
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var approvedPropertiesQuery = _context.Properties
                .Include(p => p.User)
                .Include(p => p.Reviews)
                .Include(p => p.Category)
                .Include(p => p.Reservations)
                .Where(p => p.PropertyStatus == PropertyStatus.Approved);

            // Count all approved properties before applying the filter
            int totalPropertiesCount = await approvedPropertiesQuery.CountAsync();

            // Execute the filtered query and load results
            List<Property> filteredProperties = await approvedPropertiesQuery.ToListAsync();


            ViewBag.AllCategories = GetAllCategories();
            ViewBag.AllProperties = totalPropertiesCount;
            ViewBag.SelectedProperties = filteredProperties.Count;

            return View(filteredProperties);
        }

        // this will allow a user to search for properties in the db
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

            if (!string.IsNullOrEmpty(psvm.City))
            {
                query = query.Where(p => p.City.Contains(psvm.City));
            }

            if (psvm.State != null)
            {
                query = query.Where(p => p.State == psvm.State);
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
                if (psvm.BedroomsRange == null || psvm.BedroomsRange == PSVMRange.GreaterThan)
                {
                    query = query.Where(p => p.Bedrooms >= psvm.Bedrooms);
                }
                else if (psvm.BedroomsRange == PSVMRange.LessThan)
                {
                    query = query.Where(p => p.Bedrooms <= psvm.Bedrooms);
                }
            }

            if (!string.IsNullOrEmpty(psvm.StreetAddress))
            {
                query = query.Where(p => p.StreetAddress.Contains(psvm.StreetAddress));
            }

            if (psvm.Bathrooms != null)
            {
                if (psvm.BathroomsRange == null || psvm.BathroomsRange == PSVMRange.GreaterThan)
                {
                    query = query.Where(p => p.Bathrooms >= psvm.Bathrooms);
                }
                else if (psvm.BathroomsRange == PSVMRange.LessThan)
                {
                    query = query.Where(p => p.Bathrooms <= psvm.Bathrooms);
                }
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
                    r.ReservationStatus != ReservationStatus.Cancelled &&
                    r.CheckIn < psvm.CheckOut &&
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

            // Load data into memory
            var properties = query.ToList();

            // Filter by AverageRating in memory
            if (psvm.GuestRating != null)
            {
                if (psvm.GuestRatingRange == null || psvm.GuestRatingRange == PSVMRange.GreaterThan)
                {
                    properties = properties.Where(p => p.AverageRating >= psvm.GuestRating).ToList();
                }
                else if (psvm.GuestRatingRange == PSVMRange.LessThan)
                {
                    properties = properties.Where(p => p.AverageRating <= psvm.GuestRating).ToList();
                }
            }

            int totalApprovedProperties = _context.Properties.Count(p => p.PropertyStatus == PropertyStatus.Approved);


            ViewBag.AllProperties = totalApprovedProperties;
            ViewBag.SelectedProperties = properties.Count;
            ViewBag.AllCategories = GetAllCategories();

            return View("Index", properties);
        }

        
        // this queries all the unapproved properties in the db, so the admin can approve them
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

            ViewBag.AllProperties = unapprovedProperties.Count;
            ViewBag.SelectedProperties = unapprovedProperties.Count;

            ViewBag.AllCategories = GetAllCategories();

            return View("Index", unapprovedProperties);
        }


        // this allows the admin to see all the properties that are inactive
        [Authorize(Roles = "Admin")]
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

            // Update ViewBag to reflect the count of inactive properties
            ViewBag.AllProperties = inactiveProperties.Count;
            ViewBag.SelectedProperties = inactiveProperties.Count;

            ViewBag.AllCategories = GetAllCategories();

            return View("Index", inactiveProperties);
        }

        // GET: Properties/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Hmm... you didn't provide an ID." });
            }

            var property = await _context.Properties
                .Include(p => p.Reservations)
                .Include(p => p.Reviews)
                .Include(P => P.Category)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PropertyID == id);

            if (property == null)
            {
                // Display a user-friendly error if the property doesn't exist
                return View("Error", new String[] { "Property was not found." });
            }

            // Restrict access to unapproved properties for customers
            if (property.PropertyStatus != PropertyStatus.Approved && !User.IsInRole("Host, Admin"))
            {
                return View("Error", new String[] { "You are trying to view an unapproved property. You can't!" });
            }

            // Calculate average rating for the property
            var validReviews = property.Reviews?.Where(r => r.DisputeStatus == DisputeStatus.NoDispute || r.DisputeStatus == DisputeStatus.InvalidDispute);
            ViewBag.AvgRating = validReviews != null && validReviews.Any()
                ? validReviews.Average(r => r.Rating).ToString("0.0")
                : "No Ratings Yet";

            // Query to get upcoming reservations for this property
            var upcomingReservations = _context.Reservations
                .Include(r => r.User) // Include the user who made the reservation
                .Where(r => r.Property.PropertyID == id && r.CheckIn >= DateTime.Now && r.ReservationStatus == ReservationStatus.Valid)
                .OrderBy(r => r.CheckIn)
                .ToList();

            // Pass the upcoming reservations to the view
            ViewBag.UpcomingReservations = upcomingReservations;

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
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            var myPropertiesQuery = _context.Properties
                .Include(p => p.User)
                .Include(p => p.Category)
                .Include(p => p.Reviews) // Include Reviews for rating calculation
                .Where(p => p.User.Email == user.Email);

            List<Property> myProperties = await myPropertiesQuery.ToListAsync();

            // Update ViewBag to show the total and selected properties for the host
            ViewBag.AllProperties = myProperties.Count;
            ViewBag.SelectedProperties = myProperties.Count;

            ViewBag.AllCategories = GetAllCategories();

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


       

        [HttpGet]
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "You did not provide an ID." });
            }

            // Include the property owner information
            var property = await _context.Properties
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.PropertyID == id);

            if (property == null)
            {
                return View("Error", new String[] { "The property was not found. " });
            }

            // Ensure the logged-in user is the owner of the property
            var loggedInUserId = _userManager.GetUserId(User);
            if (property.User.Id != loggedInUserId)
            {
                return View("Error", new String[] { "This property does not belong to you. " });
            }

            return View(property);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Host")]
        public async Task<IActionResult> Edit(int id, Property updatedProperty)
        {
            // Fetch the original property from the database, including UnavailableDates
            var property = await _context.Properties
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.PropertyID == id);

            if (property == null)
            {
                return View("Error", new String[] { "The property was not found." });
            }

            // Ensure the logged-in user is the owner of the property
            var loggedInUserId = _userManager.GetUserId(User);
            if (property.User.Id != loggedInUserId)
            {
                return View("Error", new String[] { "You are not the owner of this property." });
            }

            // Preserve the existing UnavailableDates
            var existingUnavailableDates = property.UnavailableDates;

            // Update only the fields that are allowed to be edited
            property.WeekdayPricing = updatedProperty.WeekdayPricing;
            property.WeekendPricing = updatedProperty.WeekendPricing;
            property.CleaningFee = updatedProperty.CleaningFee;
            property.DiscountRate = updatedProperty.DiscountRate;
            property.MinNightsforDiscount = updatedProperty.MinNightsforDiscount;

            // Reassign the preserved UnavailableDates
            property.UnavailableDates = existingUnavailableDates;

            // Save changes
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


        [HttpGet]
        [Authorize]
        public IActionResult AddUnavailableDate()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return View("Error", new string[] { "You must be logged in to manage properties." });
            }

            var properties = _context.Properties
                .Where(p => p.User.Id == userId)
                .Select(p => new
                {
                    p.PropertyID,
                    DisplayText = p.StreetAddress
                })
                .OrderBy(p => p.DisplayText)
                .ToList();

            ViewBag.Properties = new SelectList(properties, "PropertyID", "DisplayText");

            return View(new AddUnavailableDateViewModel());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddUnavailableDate(AddUnavailableDateViewModel model)
        {
            // Get the logged-in user's ID
            var userIdCheck = _userManager.GetUserId(User);

            // Fetch the property with its reservations (exclude unavailable dates from Include)
            var property = _context.Properties
                .Include(p => p.Reservations)
                .FirstOrDefault(p => p.PropertyID == model.PropertyID && p.User.Id == userIdCheck);

            if (property == null)
            {
                ViewBag.Error = "You are not authorized to manage this property.";
                ViewBag.Properties = GetAllPropertiesSelectList(userIdCheck);
                return View(model);
            }

            // Check if the unavailable date is already in the list
            if (property.UnavailableDates.Contains(model.UnavailableDate))
            {
                ViewBag.Error = "This date is already marked as unavailable.";
                ViewBag.Properties = GetAllPropertiesSelectList(userIdCheck);
                return View(model);
            }

            // Check if there are any valid reservations conflicting with the unavailable date
            bool hasValidReservationConflict = property.Reservations.Any(reservation =>
                reservation.ReservationStatus == ReservationStatus.Valid &&
                (
                    (reservation.CheckIn <= model.UnavailableDate && reservation.CheckOut > model.UnavailableDate) ||
                    reservation.CheckIn == model.UnavailableDate ||
                    reservation.CheckOut == model.UnavailableDate
                ));

            if (hasValidReservationConflict)
            {
                ViewBag.Error = "You cannot mark this date as unavailable because it conflicts with a valid reservation.";
                ViewBag.Properties = GetAllPropertiesSelectList(userIdCheck);
                return View(model);
            }

            // Add the new unavailable date to the list
            property.UnavailableDates.Add(model.UnavailableDate);

            // Save changes to the database
            try
            {
                _context.SaveChanges();
                ViewBag.Message = "Unavailable date added successfully.";
                ViewBag.Properties = GetAllPropertiesSelectList(userIdCheck);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"An error occurred while adding the unavailable date: {ex.Message}";
                ViewBag.Properties = GetAllPropertiesSelectList(userIdCheck);
                return View(model);
            }
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

        private SelectList GetAllPropertiesSelectList(string userId)
        {
            // Retrieve the list of properties for the specified user
            var properties = _context.Properties
                .Where(p => p.User.Id == userId)
                .ToList();

            // Add a default option to prompt property selection
            var propertySelectList = properties
                .Select(p => new
                {
                    p.PropertyID,
                    DisplayText = p.StreetAddress // Only show the street address
                })
                .OrderBy(p => p.DisplayText)
                .ToList();

            // Insert a default "Select a Property" entry
            propertySelectList.Insert(0, new { PropertyID = 0, DisplayText = "Select a Property" });

            return new SelectList(propertySelectList, "PropertyID", "DisplayText");
        }

    }
}
