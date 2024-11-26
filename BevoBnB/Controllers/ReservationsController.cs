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
using BevoBnB.Utilities;

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

            if (dbProperty.PropertyStatus == PropertyStatus.Unapproved)
            {
                return View("Error", new String[] { "You cannot create a reservation for a property that has not been approved for reservations. Try again later!"});
            }

            // Get the currently logged-in user
            AppUser currentUser = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

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
            // Find the property using your existing approach
            Property dbProperty = _context.Properties.Find(reservation.Property.PropertyID);

            // Collect error messages
            List<string> errorMessages = new List<string>();

            // SECURITY CHECK: Ensure property still exists and is approved
            if (dbProperty == null || dbProperty.PropertyStatus == PropertyStatus.Unapproved)
            {
                errorMessages.Add("The selected property is not available for reservations.");
            }
            else
            {
                // Check-in date must not be today
                if (DateTime.Now.Date == reservation.CheckIn.Date)
                {
                    errorMessages.Add("You cannot make a reservation that starts today.");
                }

                // Check-in and check-out dates must be in the future
                if (reservation.CheckIn.Date <= DateTime.Now.Date || reservation.CheckOut.Date <= DateTime.Now.Date)
                {
                    errorMessages.Add("Both check-in and check-out dates must be in the future.");
                }

                // Check-in date must be before the check-out date
                if (reservation.CheckIn >= reservation.CheckOut)
                {
                    errorMessages.Add("Your check-in date must be before the check-out date.");
                }

                // Ensure the number of guests does not exceed the property's limit
                if (reservation.NumOfGuests > dbProperty.GuestsAllowed)
                {
                    errorMessages.Add("The number of guests exceeds the limit for this property.");
                }

                // Check for reservation conflicts for the property itself
                if (ReservationDateConflict(reservation))
                {
                    errorMessages.Add("The selected dates conflict with an existing reservation for this property.");
                }

                // Check if the reservation falls on unavailable dates
                reservation.Property = dbProperty; // Ensure reservation is associated with the property
                if (IsReservationOnUnavailableDates(reservation))
                {
                    errorMessages.Add("The selected dates include one or more days that are unavailable for reservations.");
                }
            }

            // Display all errors if any
            if (errorMessages.Any())
            {
                ViewBag.ErrorMessages = errorMessages;
                return View(reservation);
            }

            // Get the logged-in user
            AppUser user = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            // Populate reservation details from the property
            reservation.Property = dbProperty;
            reservation.WeekdayPrice = dbProperty.WeekdayPricing;
            reservation.WeekendPrice = dbProperty.WeekendPricing;
            reservation.CleaningFee = dbProperty.CleaningFee;
            reservation.DiscountRate = reservation.TotalNights >= dbProperty.MinNightsforDiscount ? dbProperty.DiscountRate : null;
            reservation.ReservationStatus = ReservationStatus.Pending;
            reservation.User = user;

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
                ViewBag.EmptyCart = "There are no pending reservations in your shopping cart.";
                return View(new List<Reservation>());
            }

            // Calculate the totals
            ViewBag.DiscountAmount = reservations.Sum(r => r.DiscountAmount);
            ViewBag.SalesTax = reservations.Sum(r => r.SalesTax);
            ViewBag.CleaningFee = reservations.Sum(r => r.CleaningFee);
            ViewBag.StayTotal = reservations.Sum(r => r.StayTotal);
            ViewBag.Subtotal = reservations.Sum(r => r.Subtotal);
            ViewBag.Total = reservations.Sum(r => r.Total);

            // Pass the filtered reservations to the view
            return View(reservations);
        }


        public async Task<IActionResult> CheckOut()
        {
            // Retrieve all pending reservations for the logged-in user
            List<Reservation> pendingReservations = await _context.Reservations
                .Include(r => r.Property)
                .Where(r => r.User.UserName == User.Identity.Name && r.ReservationStatus == ReservationStatus.Pending)
                .ToListAsync();

            // Check if there are no pending reservations
            if (!pendingReservations.Any())
            {
                ViewBag.ErrorMessage = "Your shopping cart is empty. Add reservations to proceed with checkout.";
                return RedirectToAction(nameof(ShoppingCart));
            }

            // Error message list
            List<string> errorMessages = new List<string>();

            foreach (var reservation in pendingReservations)
            {
                var dbProperty = reservation.Property;

                // Check if the property still exists and is approved
                if (dbProperty == null || dbProperty.PropertyStatus == PropertyStatus.Unapproved)
                {
                    errorMessages.Add($"The property for reservation ID {reservation.ReservationID} is not approved or no longer exists.");
                }

                // Check-in and check-out dates must be in the future
                if (reservation.CheckIn.Date <= DateTime.Now.Date || reservation.CheckOut.Date <= DateTime.Now.Date)
                {
                    errorMessages.Add($"Reservation ID {reservation.ReservationID}: Both check-in and check-out dates must be in the future.");
                }

                // Check for reservation conflicts for the property itself
                if (ReservationDateConflict(reservation))
                {
                    errorMessages.Add($"Reservation ID {reservation.ReservationID}: The selected dates conflict with an existing reservation for this property.");
                }

                // Check if the reservation falls on unavailable dates
                if (IsReservationOnUnavailableDates(reservation))
                {
                    errorMessages.Add($"Reservation ID {reservation.ReservationID}: The selected dates include one or more unavailable days for this property.");
                }
            }

            // If there are any errors, redirect to ShoppingCart and display them
            if (errorMessages.Any())
            {
                TempData["AlertMessage"] = string.Join("<br>", errorMessages);
                return RedirectToAction(nameof(ShoppingCart));
            }

            // Assign confirmation numbers and mark reservations as valid
            foreach (var reservation in pendingReservations)
            {
                reservation.ReservationStatus = ReservationStatus.Valid;
                reservation.ConfirmationNumber = GenerateNextConfirmationNumber.GetNextConfirmationNumber(_context);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Pass the finalized reservations to the confirmation view
            return View("Success", new String[] { "YIPPIE! You transaction successfully went through."});
        }

        // GET: Reservations/Edit/5
        public IActionResult Edit(int? id)
        {
            // Check if ID is null
            if (id == null)
            {
                return View("Error", new string[] { "Please specify a reservation to edit." });
            }

            // Find the reservation in the database, include related details
            Reservation reservation = _context.Reservations
                                      .Include(r => r.Property)
                                      .Include(r => r.User)
                                      .FirstOrDefault(r => r.ReservationID == id);

            // Reservation was not found
            if (reservation == null)
            {
                return View("Error", new string[] { "This reservation was not found in the database!" });
            }

            // Reservation does not belong to the logged-in user (if customer)
            if (User.IsInRole("Customer") && reservation.User.UserName != User.Identity.Name)
            {
                return View("Error", new string[] { "You are not authorized to edit this reservation!" });
            }

            // If the reservation is valid and check-in date is in the past
            if (reservation.ReservationStatus == ReservationStatus.Valid && reservation.CheckIn.Date <= DateTime.Now.Date)
            {
                return View("Error", new string[] { "This reservation has already started or is completed and cannot be edited!" });
            }

            // Pass the reservation to the view
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationID,CheckIn,CheckOut,NumOfGuests,ReservationStatus")] Reservation reservation)
        {
            if (id != reservation.ReservationID)
            {
                return View("Error", new string[] { "Invalid reservation ID." });
            }

            // Retrieve the reservation from the database
            var dbReservation = _context.Reservations
                                         .Include(r => r.Property)
                                         .Include(r => r.User)
                                         .FirstOrDefault(r => r.ReservationID == id);

            if (dbReservation == null)
            {
                return View("Error", new string[] { "Reservation not found in the database." });
            }

            // Ensure the user is authorized to edit this reservation
            if (User.IsInRole("Customer") && dbReservation.User.UserName != User.Identity.Name)
            {
                return View("Error", new string[] { "You are not authorized to edit this reservation." });
            }

            // Handle cancellation for valid reservations
            if (dbReservation.ReservationStatus == ReservationStatus.Valid && reservation.ReservationStatus == ReservationStatus.Cancelled)
            {
                // Validate cancellation eligibility
                if (dbReservation.CheckIn <= DateTime.Now.AddDays(1))
                {
                    return View("Error", new string[] { "This reservation cannot be canceled within one day of the check-in date or after the check-in date has passed." });
                }

                // Update reservation status to cancelled
                dbReservation.ReservationStatus = ReservationStatus.Cancelled;

                try
                {
                    _context.Update(dbReservation);
                    await _context.SaveChangesAsync();
                    ViewBag.AlertMessage = "Reservation successfully canceled.";
                }
                catch (Exception ex)
                {
                    return View("Error", new string[] { $"An error occurred while canceling the reservation: {ex.Message}" });
                }

                return RedirectToAction(nameof(Index));
            }

            // Handle updates for pending reservations
            if (dbReservation.ReservationStatus == ReservationStatus.Pending)
            {
                List<string> errorMessages = new List<string>();

                var dbProperty = dbReservation.Property;

                // Check-in and check-out validation
                if (reservation.CheckIn <= DateTime.Now.Date)
                {
                    errorMessages.Add("Check-in date must be in the future.");
                }
                if (reservation.CheckIn >= reservation.CheckOut)
                {
                    errorMessages.Add("Check-out date must be after the check-in date.");
                }

                // Guest count validation
                if (reservation.NumOfGuests > dbProperty.GuestsAllowed)
                {
                    errorMessages.Add($"The number of guests exceeds the limit for this property (Max: {dbProperty.GuestsAllowed}).");
                }

                // Check for reservation conflicts
                dbReservation.CheckIn = reservation.CheckIn;
                dbReservation.CheckOut = reservation.CheckOut;

                if (ReservationDateConflict(dbReservation))
                {
                    errorMessages.Add("The selected dates conflict with an existing reservation for this property.");
                }

                // Check for unavailable dates
                if (IsReservationOnUnavailableDates(dbReservation))
                {
                    errorMessages.Add("The selected dates include one or more days that are unavailable for reservations.");
                }

                // If errors exist, show them
                if (errorMessages.Any())
                {
                    ViewBag.ErrorMessages = errorMessages;
                    return View(dbReservation);
                }

                // Update reservation fields
                dbReservation.CheckIn = reservation.CheckIn;
                dbReservation.CheckOut = reservation.CheckOut;
                dbReservation.NumOfGuests = reservation.NumOfGuests;

                try
                {
                    _context.Update(dbReservation);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return View("Error", new string[] { $"An error occurred while updating the reservation: {ex.Message}" });
                }

                return RedirectToAction(nameof(ShoppingCart));
            }

            return View("Error", new string[] { "Invalid action on reservation." });
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
            var reservation = await _context.Reservations
                                            .Include(r => r.Property)
                                            .FirstOrDefaultAsync(r => r.ReservationID == id);

            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }

            // Redirect to ShoppingCart action to reload data
            return RedirectToAction(nameof(ShoppingCart));
        }


        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationID == id);
        }

        // -------------------------------------------------------------------------------------------------------------- //
        // ------------------------------------------ Methods for Action Methods ---------------------------------------- //
        // -------------------------------------------------------------------------------------------------------------- //


        // checks whether the reservations conflicts with another
        private bool ReservationDateConflict(Reservation reservation)
        {
            // security check - no reservation was provided in the method
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
                        continue;
                    }

                    // Conflict found
                    return true;
                }
            }

            // No conflicts found
            return false; 
        }

        private bool ShoppingCartDateConflict(Reservation newReservation, List<Reservation> cartReservations)
        {
            if (newReservation == null || cartReservations == null || !cartReservations.Any())
            {
                return false;
            }

            foreach (var existingReservation in cartReservations)
            {
                // Check for overlapping dates
                if (newReservation.CheckIn < existingReservation.CheckOut &&
                    newReservation.CheckOut > existingReservation.CheckIn)
                {
                    // Allow back-to-back reservations
                    if (newReservation.CheckOut == existingReservation.CheckIn ||
                        newReservation.CheckIn == existingReservation.CheckOut)
                    {
                        continue;
                    }

                    // Conflict found
                    return true;
                }
            }

            return false;
        }


        // Checks if the reservation falls on any unavailable dates for the property
        private bool IsReservationOnUnavailableDates(Reservation reservation)
        {
            // Ensure the property exists and has unavailable dates
            if (reservation.Property == null || reservation.Property.UnavailableDates == null || !reservation.Property.UnavailableDates.Any())
            {
                return false;
            }

            // Check if any unavailable date conflicts with the reservation period
            foreach (var unavailableDate in reservation.Property.UnavailableDates)
            {
                // Check if the unavailable date equals the CheckIn, CheckOut, or falls in between
                if (unavailableDate >= reservation.CheckIn && unavailableDate < reservation.CheckOut)
                {
                    return true;
                }
            }

            // No conflicts found
            return false;
        }
    }
}
