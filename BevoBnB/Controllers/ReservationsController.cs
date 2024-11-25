using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BevoBnB.DAL;
using BevoBnB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BevoBnB.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReservationsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            // query for all reservations 
            // Set up a list of reservations to display
            List<Reservation> reservations;

            // Admin sees all reservations
            if (User.IsInRole("Admin"))
            {
                reservations = await _context.Reservations
                                .Include(r => r.Property)
                                .Where(r => r.ReservationStatus == ReservationStatus.Valid || r.ReservationStatus == ReservationStatus.Cancelled)
                                .OrderBy(r => r.ReservationID)
                                .ToListAsync();
            }

            // host should see all reservations associated with their property
            else if (User.IsInRole("Host")) 
            {
                reservations = await _context.Reservations
                                .Include(r => r.Property)
                                .Where(r => r.Property.User.UserName == User.Identity.Name 
                                    && (r.ReservationStatus == ReservationStatus.Valid || r.ReservationStatus == ReservationStatus.Cancelled))
                                .OrderBy(r => r.ReservationID)
                                .ToListAsync();
            }

            // customer should see all reservations that they've made
            else
            {
                reservations = await _context.Reservations
                                .Include(r => r.Property)
                                .Where(r => r.User.UserName == User.Identity.Name 
                                    && (r.ReservationStatus == ReservationStatus.Valid || r.ReservationStatus == ReservationStatus.Cancelled))
                                .OrderBy(r => r.ReservationID)
                                .ToListAsync();
            }

            return View(reservations);
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationID == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create(int? propertyID)
        {
            if (propertyID == null)
            {
                return View("Error", new String[] { "The user did not specify an ID. Try again!" });
            }

            Property dbProperty = _context.Properties.Find(propertyID);

            if (dbProperty == null)
            {
                return View("Error", new String[] { "There is no property with that ID. Try again!" });
            }

            // Pre-fill reservation with property details
            Reservation reservation = new Reservation
            {
                Property = dbProperty
            };

            return View(reservation);
        }


        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationID,CheckIn,CheckOut,NumOfGuests,WeekdayPrice,WeekendPrice,CleaningFee,DiscountRate,Tax,ConfirmationNumber,ReservationStatus")] Reservation reservation)
        {
            if (id != reservation.ReservationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationID))
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
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationID == id);
        }
    }
}
