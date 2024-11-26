using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BevoBnB.DAL;
using BevoBnB.Models;

namespace BevoBnB.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly AppDbContext _context;

        public PropertiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Properties
        // Updated Index method for handling guests and range filtering
        public async Task<IActionResult> Index(string searchString, int? bedrooms, int? bathrooms, decimal? minPrice, decimal? maxPrice, int? guestsAllowed, bool? petsAllowed, bool? freeParking)
        {
            // Base query to retrieve all properties
            var query = _context.Properties.AsQueryable();

            // Apply SQL-compatible filters
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p =>
                    (p.City != null && EF.Functions.Like(p.City, $"%{searchString}%")) ||
                    (p.State.ToString() == searchString.ToUpper()) || // Exact match for state enum
                    (p.StreetAddress != null && EF.Functions.Like(p.StreetAddress, $"%{searchString}%")) ||
                    (p.ZipCode != null && EF.Functions.Like(p.ZipCode, $"%{searchString}%"))
                );
            }

            if (bedrooms.HasValue)
            {
                query = query.Where(p => p.Bedrooms == bedrooms.Value);
            }

            if (bathrooms.HasValue)
            {
                query = query.Where(p => p.Bathrooms == bathrooms.Value);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.WeekdayPricing >= minPrice || p.WeekendPricing >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.WeekdayPricing <= maxPrice || p.WeekendPricing <= maxPrice);
            }

            if (guestsAllowed.HasValue)
            {
                query = query.Where(p => p.GuestsAllowed == guestsAllowed.Value);
            }

            if (petsAllowed.HasValue)
            {
                query = query.Where(p => p.PetsAllowed == petsAllowed.Value);
            }

            if (freeParking.HasValue)
            {
                query = query.Where(p => p.FreeParking == freeParking.Value);
            }

            // Execute the query
            var selectedProperties = await query.ToListAsync();

            // Handle message for no results
            if (!selectedProperties.Any())
            {
                ViewBag.NoResultsMessage = "No properties meet your search criteria.";
            }

            // Populate ViewBag with counts for display
            ViewBag.AllProperties = _context.Properties.Count(); // Total number of properties
            ViewBag.SelectedProperties = selectedProperties.Count; // Number of matched properties

            // Sort results by City (or another property, if desired)
            return View(selectedProperties.OrderBy(p => p.City).ToList());
        }

        // GET: Properties/Details/5
        //TODO: this needs to return error views.not status 404 not found. 
        //TODO: it should also return the avg rating, this should be an easy linq query that returns the avg for the property
        //TODO: the view should not be viewable by the customer if it's unapproved
        //TODO: only a host and admin may see the view if it's unapproved
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include the related Reviews when fetching the Property
            var property = await _context.Properties
                .Include(p => p.Reviews) // Include the Reviews navigation property
                .FirstOrDefaultAsync(m => m.PropertyID == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }


        // GET: Properties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyID,PropertyNumber,StreetAddress,City,State,ZipCode,Bedrooms,Bathrooms,GuestsAllowed,PetsAllowed,FreeParking,WeekdayPricing,WeekendPricing,CleaningFee,DiscountRate,MinNightsforDiscount,UnavailableDates,PropertyStatus")] Property @property)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@property);
        }

        // GET: Properties/Edit/5
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
