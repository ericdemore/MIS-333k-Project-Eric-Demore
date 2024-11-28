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

        // GET: Properties
        public async Task<IActionResult> Index()
        {
            List<Property> activeProperties;

            activeProperties = await _context.Properties
                .Include(p => p.Category)
                .Include(p => p.Reviews)
                .Include(p => p.User)
                .Where(p => p.PropertyStatus == PropertyStatus.Approved)
                .OrderBy(p => p.City)
                .ThenBy(p => p.State)
                .ThenBy(p => p.PropertyID)
                .ToListAsync();

            ViewBag.TotalItems = activeProperties.Count;

            return View(activeProperties);
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

            ViewBag.TotalItems = unapprovedProperties.Count;

            return View("Index", unapprovedProperties);
        }

        public async Task<IActionResult> Inactive(int? page)
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

            ViewBag.TotalItems = inactiveProperties.Count;

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


        // GET: Properties/DetailedSearch
        public IActionResult DetailedSearch()
        {
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

        [HttpGet]
        public IActionResult DisplaySearchResults(PropertySearchViewModel searchModel)
        {
            // Redirect to Index with search criteria
            return RedirectToAction("Index", new
            {
                city = searchModel.City,
                state = searchModel.State,
                categoryId = searchModel.CategoryId,
                bedrooms = searchModel.Bedrooms,
                bathrooms = searchModel.Bathrooms,
                minPrice = searchModel.MinPrice,
                maxPrice = searchModel.MaxPrice,
                guestsAllowed = searchModel.GuestsAllowed,
                petsAllowed = searchModel.PetsAllowed,
                freeParking = searchModel.FreeParking
            });
        }

        //// GET: Properties/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Properties/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PropertyID,PropertyNumber,StreetAddress,City,State,ZipCode,Bedrooms,Bathrooms,GuestsAllowed,PetsAllowed,FreeParking,WeekdayPricing,WeekendPricing,CleaningFee,DiscountRate,MinNightsforDiscount,UnavailableDates,PropertyStatus")] Property @property)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(@property);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(@property);
        //}

        // GET: Properties/Edit/5

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreetAddress,City,State,ZipCode,Bedrooms,Bathrooms,GuestsAllowed,PetsAllowed,FreeParking,WeekdayPricing,WeekendPricing,CleaningFee,DiscountRate,MinNightsforDiscount")] Property property)
        {
            // Restrict access to hosts
            if (!User.IsInRole("Host"))
            {
                ViewBag.ErrorMessage = "Only hosts are authorized to create properties.";
                return View("Error"); // Redirect to an error view
            }

            if (ModelState.IsValid)
            {
                // Automatically generate a unique property number
                property.PropertyNumber = GeneratePropertyNumber();

                // Automatically set the default property status to Unapproved
                property.PropertyStatus = PropertyStatus.Unapproved; // Use the enum value

                // Add the property to the database
                _context.Add(property);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(property);
        }

        // Helper method to generate a unique property number
        private int GeneratePropertyNumber()
        {
            // Generate a random property number
            Random random = new Random();
            int propertyNumber;

            // Ensure the property number is unique
            do
            {
                propertyNumber = random.Next(1000, 9999); // Generate a number between 1000 and 9999
            } while (_context.Properties.Any(p => p.PropertyNumber == propertyNumber));

            return propertyNumber;
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
    }
}
