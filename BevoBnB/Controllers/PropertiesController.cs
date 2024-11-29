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
    public class PropertiesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PropertiesController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //// GET: Properties
        //public async Task<IActionResult> Index(string? searchString)
        //{
        //    List<Property> propertiesToDisplay;

        //    // Base query for fetching properties
        //    IQueryable<Property> query;

        //    // Check the user's role
        //    if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
        //    {
        //        // Admins can see all properties
        //        query = _context.Properties
        //            .Include(p => p.Category)
        //            .Include(p => p.Reviews)
        //            .Include(p => p.User)
        //            .OrderBy(p => p.City)
        //            .ThenBy(p => p.State)
        //            .ThenBy(p => p.PropertyID);

        //        ViewBag.TotalItems = await _context.Properties.CountAsync(); // Admins see total count
        //    }
        //    else
        //    {
        //        // Non-admins (customers or not logged in) can only see approved properties
        //        query = _context.Properties
        //            .Include(p => p.Category)
        //            .Include(p => p.Reviews)
        //            .Include(p => p.User)
        //            .Where(p => p.PropertyStatus == PropertyStatus.Approved) // Only approved
        //            .OrderBy(p => p.City)
        //            .ThenBy(p => p.State)
        //            .ThenBy(p => p.PropertyID);

        //        ViewBag.TotalItems = await _context.Properties.CountAsync(); // Total includes all properties
        //    }

        //    // Apply search filter if a search string is provided
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        query = query.Where(p => p.City.Contains(searchString) ||
        //                                 p.State.ToString().Contains(searchString) ||
        //                                 p.StreetAddress.Contains(searchString) ||
        //                                 p.ZipCode.Contains(searchString));
        //    }

        //    // Execute the query and retrieve the results
        //    propertiesToDisplay = await query.ToListAsync();

        //    // Reflect the count of displayed properties
        //    ViewBag.SelectedProperties = propertiesToDisplay.Count;

        //    // Set the ViewBag message for the results
        //    ViewBag.Message = $"Showing {ViewBag.SelectedProperties} out of {ViewBag.TotalItems} properties.";

        //    return View(propertiesToDisplay);
        //}

        // GET: Properties
        // GET: Properties
        public async Task<IActionResult> Index(
            string? searchString, // Combine general search into one parameter
            int? categoryId,
            int? bedrooms,
            int? bathrooms,
            decimal? minPrice,
            decimal? maxPrice,
            int? guestsAllowed,
            bool? petsAllowed,
            bool? freeParking)
        {
            IQueryable<Property> query;

            // Check if user is an Admin
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                query = _context.Properties
                    .Include(p => p.Category)
                    .Include(p => p.Reviews)
                    .Include(p => p.User);
            }
            else
            {
                query = _context.Properties
                    .Include(p => p.Category)
                    .Include(p => p.Reviews)
                    .Include(p => p.User)
                    .Where(p => p.PropertyStatus == PropertyStatus.Approved); // Non-admins only see approved properties
            }

            // Apply general search logic (combined city and state)
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p =>
                    (p.City != null && EF.Functions.Like(p.City, $"%{searchString}%")) || // Match city
                    (p.State != null && EF.Functions.Like(p.State.ToString(), $"%{searchString.ToUpper()}%")) // Match state
                );
            }

            // Apply detailed search filters
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.Category.CategoryID == categoryId.Value);
            }

            if (bedrooms.HasValue)
            {
                query = query.Where(p => p.Bedrooms >= bedrooms.Value);
            }

            if (bathrooms.HasValue)
            {
                query = query.Where(p => p.Bathrooms >= bathrooms.Value);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.WeekdayPricing >= minPrice.Value || p.WeekendPricing >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.WeekdayPricing <= maxPrice.Value || p.WeekendPricing <= maxPrice.Value);
            }

            if (guestsAllowed.HasValue)
            {
                query = query.Where(p => p.GuestsAllowed >= guestsAllowed.Value);
            }

            if (petsAllowed.HasValue)
            {
                query = query.Where(p => p.PetsAllowed == true);
            }

            if (freeParking.HasValue)
            {
                query = query.Where(p => p.FreeParking == true);
            }

            // Execute query and load results
            var propertiesToDisplay = await query
                .OrderBy(p => p.City)
                .ThenBy(p => p.State)
                .ThenBy(p => p.PropertyID)
                .ToListAsync();

            // Set ViewBag values
            ViewBag.TotalItems = await _context.Properties.CountAsync();
            ViewBag.SelectedProperties = propertiesToDisplay.Count;
            ViewBag.Message = propertiesToDisplay.Any()
                ? $"Showing {ViewBag.SelectedProperties} out of {ViewBag.TotalItems} properties."
                : "No properties match your search criteria.";

            return View(propertiesToDisplay);
        }


        public async Task<IActionResult> Unapproved()
        {
            List<Property> unapprovedProperties;

            unapprovedProperties = await _context.Properties
                .Include(p => p.Category)
                .Include(p => p.Reviews)
                .Include(p => p.User)
                .Where(p => p.PropertyStatus == PropertyStatus.Unapproved)
                .OrderBy(p => p.City)
                .ThenBy(p => p.State)
                .ThenBy(p => p.PropertyID)
                .ToListAsync();

            // Set ViewBag for total properties and current results
            ViewBag.TotalItems = _context.Properties.Count(); // Total properties
            ViewBag.CurrentItems = unapprovedProperties.Count;
            ViewBag.Message = $"Showing {ViewBag.CurrentItems} out of {ViewBag.TotalItems} properties.";

            return View("Index", unapprovedProperties);
        }

        public async Task<IActionResult> Inactive()
        {
            List<Property> inactiveProperties;

            inactiveProperties = await _context.Properties
                .Include(p => p.Category)
                .Include(p => p.Reviews)
                .Include(p => p.User)
                .Where(p => p.PropertyStatus == PropertyStatus.Inactive)
                .OrderBy(p => p.City)
                .ThenBy(p => p.State)
                .ThenBy(p => p.PropertyID)
                .ToListAsync();

            // Set ViewBag for total properties and current results
            ViewBag.TotalItems = _context.Properties.Count(); // Total properties
            ViewBag.CurrentItems = inactiveProperties.Count;
            ViewBag.Message = $"Showing {ViewBag.CurrentItems} out of {ViewBag.TotalItems} properties.";

            return View("Index", inactiveProperties);
        }



        // GET: Properties/Details/5
        //TODO: this needs to return error views, not status 404 not found. 
        //TODO: it should also return the avg rating, this should be an easy linq query that returns the avg for the property
        //TODO: the view should not be viewable by the customer if it's unapproved
        //TODO: only a host and admin may see the view if it's unapproved
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


        //// GET: Properties/DetailedSearch
        //public IActionResult DetailedSearch()
        //{
        //    var categories = _context.Categories.Select(c => new SelectListItem
        //    {
        //        Value = c.CategoryID.ToString(),
        //        Text = c.CategoryName
        //    }).ToList();

        //    var states = Enum.GetValues(typeof(States)).Cast<States>().Select(s => new SelectListItem
        //    {
        //        Value = s.ToString(),
        //        Text = s.ToString()
        //    }).ToList();

        //    // Debugging
        //    Console.WriteLine($"Categories Count: {categories.Count}"); // Ensure categories are being loaded
        //    Console.WriteLine($"States Count: {states.Count}"); // Ensure states enum is being loaded

        //    var viewModel = new PropertySearchViewModel
        //    {
        //        Categories = categories,
        //        States = states
        //    };

        //    return View(viewModel);
        //}

        //[HttpGet]
        //public IActionResult DisplaySearchResults(PropertySearchViewModel searchModel)
        //{
        //    // Redirect to Index with search criteria
        //    return RedirectToAction("Index", new
        //    {
        //        city = searchModel.City,
        //        state = searchModel.State,
        //        categoryId = searchModel.CategoryId,
        //        bedrooms = searchModel.Bedrooms,
        //        bathrooms = searchModel.Bathrooms,
        //        minPrice = searchModel.MinPrice,
        //        maxPrice = searchModel.MaxPrice,
        //        guestsAllowed = searchModel.GuestsAllowed,
        //        petsAllowed = searchModel.PetsAllowed,
        //        freeParking = searchModel.FreeParking
        //    });
        //}

        // GET: Properties/DetailedSearch
public IActionResult DetailedSearch()
{
    // Load categories and states for dropdowns
    var categories = _context.Categories.Select(c => new SelectListItem
    {
        Value = c.CategoryID.ToString(),
        Text = c.CategoryName
    }).ToList();

    var states = Enum.GetValues(typeof(States)).Cast<States>().Select(s => new SelectListItem
    {
        Value = s.ToString(),
        Text = s.ToString()
    }).ToList();

    // Debugging
    Console.WriteLine($"Categories Count: {categories.Count}"); // Ensure categories are being loaded
    Console.WriteLine($"States Count: {states.Count}"); // Ensure states enum is being loaded

    var viewModel = new PropertySearchViewModel
    {
        Categories = categories,
        States = states
    };

    return View(viewModel);
}

// POST: Properties/DisplaySearchResults
[HttpPost]
public async Task<IActionResult> DisplaySearchResults(PropertySearchViewModel searchModel)
{
    // Start with all properties
    IQueryable<Property> query = _context.Properties
        .Include(p => p.Category)
        .Include(p => p.Reviews)
        .Include(p => p.User);

    // Apply filters based on search model inputs
    if (!string.IsNullOrEmpty(searchModel.City))
    {
        query = query.Where(p => p.City.Contains(searchModel.City, StringComparison.OrdinalIgnoreCase));
    }

    if (!string.IsNullOrEmpty(searchModel.State) && searchModel.State != "All States")
    {
        query = query.Where(p => p.State.ToString() == searchModel.State);
    }

    if (searchModel.CategoryId.HasValue)
    {
        query = query.Where(p => p.Category.CategoryID == searchModel.CategoryId.Value);
    }

    if (searchModel.Bedrooms.HasValue)
    {
        query = query.Where(p => p.Bedrooms >= searchModel.Bedrooms.Value);
    }

    if (searchModel.Bathrooms.HasValue)
    {
        query = query.Where(p => p.Bathrooms >= searchModel.Bathrooms.Value);
    }

    if (searchModel.MinPrice.HasValue)
    {
        query = query.Where(p => p.WeekdayPricing >= searchModel.MinPrice.Value || p.WeekendPricing >= searchModel.MinPrice.Value);
    }

    if (searchModel.MaxPrice.HasValue)
    {
        query = query.Where(p => p.WeekdayPricing <= searchModel.MaxPrice.Value || p.WeekendPricing <= searchModel.MaxPrice.Value);
    }

    if (searchModel.GuestsAllowed.HasValue)
    {
        query = query.Where(p => p.GuestsAllowed >= searchModel.GuestsAllowed.Value);
    }

            if (searchModel.GuestsAllowed.HasValue)
            {
                query = query.Where(p => p.GuestsAllowed >= searchModel.GuestsAllowed.Value);
            }

            if (searchModel.PetsAllowed)
            {
                query = query.Where(p => p.PetsAllowed == true); // Show only properties that allow pets
            }

            if (searchModel.FreeParking)
            {
                query = query.Where(p => p.FreeParking == true); // Show only properties with free parking
            }

            // Restrict results based on user role
            if (!User.Identity.IsAuthenticated || User.IsInRole("Customer"))
    {
        query = query.Where(p => p.PropertyStatus == PropertyStatus.Approved); // Only approved properties
    }

    // Execute the query
    var filteredProperties = await query
        .OrderBy(p => p.City)
        .ThenBy(p => p.State)
        .ThenBy(p => p.PropertyID)
        .ToListAsync();

    // Set ViewBag messages for search results
    ViewBag.TotalItems = await _context.Properties.CountAsync();
    ViewBag.SelectedProperties = filteredProperties.Count;
    ViewBag.Message = filteredProperties.Any()
        ? $"Showing {ViewBag.SelectedProperties} out of {ViewBag.TotalItems} properties."
        : "No properties match your search criteria.";

    // Return the Index view with filtered properties
    return View("Index", filteredProperties);
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
        public async Task<IActionResult> Create(Property property)
        {
            // Restrict access to hosts
            if (User.IsInRole("Host") == false)
            {
                return View("Error");
            }

            property.PropertyNumber = Utilities.GenerateNextPropertyNumber.GetNextPropertyNumber(_context);
            property.PropertyStatus = PropertyStatus.Unapproved;
            property.UnavailableDates = new List<DateTime>();

            _context.Add(property);
            await _context.SaveChangesAsync();

            return View("Details", property);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            return View(@property);
        }

        // POST: Properties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyID,PropertyNumber,StreetAddress,City,State,ZipCode,Bedrooms,Bathrooms,GuestsAllowed,PetsAllowed,FreeParking,WeekdayPricing,WeekendPricing,CleaningFee,DiscountRate,MinNightsforDiscount,UnavailableDates,PropertyStatus")] Property @property)
        {
            if (id != @property.PropertyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.PropertyID))
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
            return View(@property);
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

    }
}
