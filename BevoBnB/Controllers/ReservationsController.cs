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
        [Authorize(Roles = "Customer, Host, Admin")]
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
                                .Where(r => r.ReservationStatus == ReservationStatus.Valid || r.ReservationStatus == ReservationStatus.Cancelled || r.ReservationStatus == ReservationStatus.Pending)
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

            AppUser customer;

            customer = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            ViewBag.Customer = customer.FirstName + " " + customer.LastName;

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Create(int? propertyID)
        {
            if (propertyID == null)
            {
                return View("Error", new string[] { "The user did not specify an ID. Try again!" });
            }

            // Find the property in the database
            Property dbProperty = _context.Properties.Find(propertyID);

            if (dbProperty == null)
            {
                return View("Error", new string[] { "There is no property with that ID. Try again!" });
            }

            // Get the currently logged-in user
            AppUser currentUser = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (currentUser == null)
            {
                return View("Error", new string[] { "The logged-in user could not be found. Try again!" });
            }

            // Create the reservation with property details
            var reservation = new Reservation
            {
                WeekdayPrice = dbProperty.WeekdayPricing,
                WeekendPrice = dbProperty.WeekendPricing,
                CleaningFee = dbProperty.CleaningFee,
                DiscountRate = dbProperty.DiscountRate,
                Property = dbProperty,
                User = currentUser,
                ReservationStatus = ReservationStatus.Pending
            };

            return View(reservation);
        }




        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public IActionResult Create(Reservation reservation)
        {
            // find the db property again
            var dbProperty = _context.Properties.Find(reservation.Property.PropertyID);

            // Check if the property exists
            if (dbProperty == null)
            {
                ViewBag.ErrorMessage = "The specified property does not exist. Please try again.";
                return View(reservation);
            }

            // Check in cannot be today
            if (DateTime.Now.Date == reservation.CheckIn.Date)
            {
                ViewBag.ErrorMessage = "You cannot make a reservation that starts today.";
                return View(reservation);
            }

            // Check-in date must be before the check-out date
            if (reservation.CheckIn >= reservation.CheckOut)
            {
                ViewBag.ErrorMessage = "Your check-in date must be before the check-out date.";
                return View(reservation);
            }

            // Check if the number of guests exceeds the limit for this property
            if (reservation.NumOfGuests > dbProperty.GuestsAllowed)
            {
                ViewBag.ErrorMessage = "The number of guests exceeds the limit for this property.";
                return View(reservation);
            }

            // Check for date conflicts
            if (ReservationDateConflict(reservation))
            {
                ViewBag.ErrorMessage = "The selected dates conflict with an existing reservation.";
                return View(reservation);
            }

            // Populate additional reservation details
            reservation.Property = dbProperty;
            reservation.WeekdayPrice = dbProperty.WeekdayPricing;
            reservation.WeekendPrice = dbProperty.WeekendPricing;
            reservation.CleaningFee = dbProperty.CleaningFee;
            reservation.DiscountRate = dbProperty.DiscountRate;
            reservation.ReservationStatus = ReservationStatus.Pending;

            // Assign the logged-in user
            reservation.User = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            // Save the reservation
            _context.Add(reservation);
            _context.SaveChanges();

            // Redirect to the Details view
            return RedirectToAction("Details", new { id = reservation.ReservationID });
        }

        public IActionResult ShoppingCart()
        {
            // Get only reservations for the current user with "Pending" status
            List<Reservation> reservations = _context.Reservations
                .Include(r => r.Property)
                .Include(r => r.User)
                .Where(r => r.User.UserName == User.Identity.Name && r.ReservationStatus == ReservationStatus.Pending)
                .ToList();

            if (reservations == null || reservations.Count == 0)
            {
                string message = "There are no pending reservations in your shopping cart.";
                ViewBag.EmptyCart = message;
                return View();
            }

            // Pass the filtered reservations to the view
            return View(reservations);
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

        // checks whether the reservations conflicts with another
        private bool ReservationDateConflict(Reservation reservation)
        {
            if (reservation.Property == null)
            {
                return false;
            }

            var existingReservations = _context.Reservations
                .Where(r => r.Property.PropertyID == reservation.Property.PropertyID &&
                            r.ReservationStatus != ReservationStatus.Cancelled &&
                            r.ReservationStatus != ReservationStatus.Pending)
                .ToList();

            foreach (var existingReservation in existingReservations)
            {
                // Check for overlapping dates
                if (reservation.CheckIn < existingReservation.CheckOut && reservation.CheckOut > existingReservation.CheckIn)
                {
                    // Allow edge cases (back-to-back reservations)
                    if (reservation.CheckOut == existingReservation.CheckIn ||
                        reservation.CheckIn == existingReservation.CheckOut)
                    {
                        continue; // No conflict for edge cases
                    }

                    // Conflict found
                    return true;
                }
            }

            // No conflicts found
            return false; 
        }
    }
}
