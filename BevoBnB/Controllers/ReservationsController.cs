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
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Property)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReservationID == id);

            ViewBag.Customer = reservation.User.FirstName + " " + reservation.User.LastName;   

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // NOTE: the admin needs to access reservation creation from Reservation/Details, so it passes the property id
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SelectCustomerForRegistration(string? selectedCustomer, int? propertyID)
        {
            Property dbProperty = _context.Properties.Find(propertyID);

            if (dbProperty.PropertyStatus == PropertyStatus.Unapproved)
            {
                return View("Error", new String[] { "You cannot make a reservation for a property that is unapproved" });
            }

            if (dbProperty.PropertyStatus == PropertyStatus.Inactive)
            {
                return View("Error", new String[] { "You cannot make a reservation for a property that is active." });
            }

            // no id was passed on, so we cannot make a reservation
            if (propertyID == null)
            {
                return View("Error", new string[] { "The user did not specify an ID. Try again!" });
            }

            // no user was selected, return them to the page with the same information
            if (string.IsNullOrEmpty(selectedCustomer))
            {
                ViewBag.UserNames = await GetAllCustomerUserNamesSelectList();
                ViewBag.PropertyID = propertyID;
                return View("SelectCustomerForRegistration");
            }

            // Redirect to the Create method with the selected customer and propertyID
            return RedirectToAction("Create", new { selectedCustomer, propertyID });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SelectCustomerShoppingCart(string? selectedCustomer)
        {
            if (string.IsNullOrEmpty(selectedCustomer))
            {
                // If no customer is selected, return to the selection view
                ViewBag.UserNames = await GetShoppingCustomerUserNamesSelectList();
                return View("SelectCustomerShoppingCart");
            }

            // Redirect to ShoppingCart with the selected customer's ID
            return RedirectToAction("ShoppingCart", new { customerId = selectedCustomer });
        }


        [Authorize(Roles = "Customer, Admin")]
        public IActionResult Create(int? propertyID, string? selectedCustomer)
        {
            // no id was passed on, so we cannot make a reservation
            if (propertyID == null)
            {
                return View("Error", new string[] { "The user did not specify an ID. Try again!" });
            }

            // find the property we're trying to make a reservation for
            Property dbProperty = _context.Properties.Find(propertyID);

            // if the desired property was not found, the we cannnot make the reservation
            if (dbProperty == null)
            {
                return View("Error", new string[] { "There is no property with that ID. Try again!" });
            }

            // if the property is still not approved return them to 
            if (dbProperty.PropertyStatus == PropertyStatus.Unapproved)
            {
                return View("Error", new String[] { "You cannot create a reservation for a property that has not been approved for reservations. Try again later!" });
            }

            // if the property is still not approved return them to 
            if (dbProperty.PropertyStatus == PropertyStatus.Inactive)
            {
                return View("Error", new String[] { "You cannot create a reservation for a property that has been listed as inactive. Try again later!" });
            }

            AppUser reservationUser;

            // Determine the user to associate with the reservation
            if (User.IsInRole("Admin"))
            {
                if (string.IsNullOrEmpty(selectedCustomer))
                {
                    return View("Error", new String[] { "No customer was selected. Please select a customer first." });
                }

                // Admin is creating a reservation for a selected customer
                reservationUser = _userManager.Users.FirstOrDefault(u => u.UserName == selectedCustomer);
                if (reservationUser == null)
                {
                    return View("Error", new String[] { "The selected customer does not exist. Try again!" });
                }
            }
            else
            {
                // Customer is creating their own reservation
                reservationUser = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            }

            // Create the reservation with property details
            var reservation = new Reservation
            {
                WeekdayPrice = dbProperty.WeekdayPricing,
                WeekendPrice = dbProperty.WeekendPricing,
                CleaningFee = dbProperty.CleaningFee,
                DiscountRate = dbProperty.DiscountRate,
                Property = dbProperty,
                User = reservationUser,
                ReservationStatus = ReservationStatus.Pending
            };

            return View(reservation);
        }


        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer, Admin")]
        public IActionResult Create(Reservation reservation)
        {
            Property dbProperty = _context.Properties.Find(reservation.Property.PropertyID);

            List<string> errorMessages = new List<string>();

            // SECURITY CHECK: Ensure property still exists and is approved
            if (dbProperty == null || dbProperty.PropertyStatus == PropertyStatus.Unapproved || dbProperty.PropertyStatus == PropertyStatus.Inactive)
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

                if (ExistingReservationsAlready(reservation))
                {
                    errorMessages.Add("You already have a reservation that overlaps with these dates.");
                }
            }

            AppUser reservationUser;

            // Determine the user to associate with the reservation
            if (User.IsInRole("Admin") && !string.IsNullOrEmpty(reservation.User?.UserName))
            {
                reservationUser = _userManager.Users.FirstOrDefault(u => u.UserName == reservation.User.UserName);

                if (reservationUser == null)
                {
                    return View("Error", new string[] { "The selected customer does not exist. Please try again!" });
                }
            }
            else
            {
                // Customer creating their own reservation
                reservationUser = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            }

            // Check for conflicts in the selected customer's shopping cart
            var userShoppingCart = _context.Reservations
                .Where(r => r.User.Id == reservationUser.Id && r.ReservationStatus == ReservationStatus.Pending)
                .ToList();

            if (ShoppingCartDateConflict(reservation, userShoppingCart))
            {
                errorMessages.Add("The selected dates conflict with a pending reservation in the customer's shopping cart.");
            }

            // Display all errors if any
            if (errorMessages.Any())
            {
                ViewBag.ErrorMessages = errorMessages;
                return View(reservation);
            }

            // Populate reservation details
            reservation.Property = dbProperty;
            reservation.User = reservationUser;
            reservation.WeekdayPrice = dbProperty.WeekdayPricing;
            reservation.WeekendPrice = dbProperty.WeekendPricing;
            reservation.CleaningFee = dbProperty.CleaningFee;
            reservation.DiscountRate = reservation.TotalNights >= dbProperty.MinNightsforDiscount ? dbProperty.DiscountRate : null;
            reservation.ReservationStatus = ReservationStatus.Pending;

            _context.Add(reservation);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = reservation.ReservationID });
        }

        public async Task<IActionResult> ShoppingCart(string? customerId = null)
        {
            List<Reservation> reservations = new List<Reservation>();
            AppUser user;

            if (!string.IsNullOrEmpty(customerId) && User.IsInRole("Admin"))
            {
                // Admin scenario: Fetch reservations for the specified customer
                user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == customerId);
                if (user == null)
                {
                    ViewBag.EmptyCart = "The selected customer does not exist.";
                    return View(reservations);
                }
                ViewBag.CustomerId = customerId; // Set customerId for admin
            }
            else
            {
                // Customer scenario: Fetch reservations for the logged-in user
                user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
                if (user == null)
                {
                    ViewBag.EmptyCart = "Unable to identify your account. Please log in again.";
                    return View(reservations);
                }
                ViewBag.CustomerId = user.Id; // Set current user's ID for customer
            }

            reservations = await _context.Reservations
                .Include(r => r.Property)
                .Where(r => r.User.Id == user.Id && r.ReservationStatus == ReservationStatus.Pending)
                .ToListAsync();

            if (!reservations.Any())
            {
                // Message for an empty cart
                ViewBag.EmptyCart = "Your shopping cart is empty. Add some reservations to check out.";
            }
            else
            {
                // Calculate totals for non-empty cart
                ViewBag.StayTotal = reservations.Sum(r => r.StayTotal);
                ViewBag.CleaningFee = reservations.Sum(r => r.CleaningFee);
                ViewBag.Subtotal = reservations.Sum(r => r.Subtotal);
                ViewBag.SalesTax = reservations.Sum(r => r.SalesTax);
                ViewBag.DiscountAmount = reservations.Sum(r => r.DiscountAmount);
                ViewBag.Total = reservations.Sum(r => r.Total);
            }

            return View(reservations);
        }



        [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> CheckOut(string? customerId = null)
        {
            List<Reservation> pendingReservations;
            AppUser user;

            // Determine user based on role
            if (!string.IsNullOrEmpty(customerId) && User.IsInRole("Admin"))
            {
                // Admin scenario: Fetch reservations for the specified customer
                user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == customerId);
                if (user == null)
                {
                    TempData["AlertMessage"] = "The selected customer does not exist.";
                    return RedirectToAction(nameof(ShoppingCart), new { customerId });
                }
            }
            else
            {
                // Customer scenario: Fetch reservations for the logged-in user
                user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
                if (user == null)
                {
                    TempData["AlertMessage"] = "Unable to identify your account. Please log in again.";
                    return RedirectToAction(nameof(ShoppingCart));
                }
            }

            // Fetch pending reservations for the user
            pendingReservations = await _context.Reservations
                .Include(r => r.Property)
                .Where(r => r.User.Id == user.Id && r.ReservationStatus == ReservationStatus.Pending)
                .ToListAsync();

            if (!pendingReservations.Any())
            {
                TempData["AlertMessage"] = "The shopping cart is empty. Add reservations to proceed with checkout.";
                return RedirectToAction(nameof(ShoppingCart), new { customerId });
            }

            // Error validation
            List<string> errorMessages = new List<string>();
            foreach (var reservation in pendingReservations)
            {
                var dbProperty = reservation.Property;

                if (ExistingReservationsAlready(reservation))
                {
                    errorMessages.Add($"The reservation for '{reservation.ReservationID}' conflicts with an existing reservation during the selected dates.");
                }

                if (dbProperty == null || dbProperty.PropertyStatus == PropertyStatus.Unapproved || dbProperty.PropertyStatus == PropertyStatus.Inactive)
                {
                    errorMessages.Add($"The property for reservation ID {reservation.ReservationID} is not approved or no longer exists.");
                }

                if (reservation.CheckIn.Date <= DateTime.Now.Date || reservation.CheckOut.Date <= DateTime.Now.Date)
                {
                    errorMessages.Add($"Reservation ID {reservation.ReservationID}: Both check-in and check-out dates must be in the future.");
                }

                if (ReservationDateConflict(reservation))
                {
                    errorMessages.Add($"Reservation ID {reservation.ReservationID}: The selected dates conflict with an existing reservation for this property.");
                }

                if (IsReservationOnUnavailableDates(reservation))
                {
                    errorMessages.Add($"Reservation ID {reservation.ReservationID}: The selected dates include one or more unavailable days for this property.");
                }
            }

            if (errorMessages.Any())
            {
                TempData["AlertMessage"] = string.Join("<br>", errorMessages);
                return RedirectToAction(nameof(ShoppingCart), new { customerId });
            }

            // Generate a single confirmation number for the transaction
            int transactionConfirmationNumber = GenerateNextConfirmationNumber.GetNextConfirmationNumber(_context);

            foreach (var reservation in pendingReservations)
            {
                reservation.ReservationStatus = ReservationStatus.Valid;
                reservation.ConfirmationNumber = transactionConfirmationNumber;
            }

            await _context.SaveChangesAsync();

            // Prepare success message
            string successMessage = $"Transaction completed. Enjoy your stay! Confirmation Number: {transactionConfirmationNumber}";

            return View("Success", new[] { successMessage });
        }





        // GET: Reservations/Edit/5
        [Authorize(Roles = "Customer, Host")]
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

            // Ensure the user is authorized to edit this reservation
            if (User.IsInRole("Customer") && reservation.User.UserName != User.Identity.Name)
            {
                return View("Error", new string[] { "You are not authorized to edit this reservation!" });
            }
            else if (User.IsInRole("Host") && reservation.Property.User.UserName != User.Identity.Name)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer, Host")]
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
            else if (User.IsInRole("Host") && dbReservation.Property.User.UserName != User.Identity.Name)
            {
                return View("Error", new string[] { "You are not authorized to edit this reservation!" });
            }

            // Handle cancellation for valid reservations by the host or customer
            if (dbReservation.ReservationStatus == ReservationStatus.Valid && reservation.ReservationStatus == ReservationStatus.Cancelled)
            {
                // Hosts can only cancel reservations more than one day before the check-in date
                if (User.IsInRole("Host") && dbReservation.CheckIn <= DateTime.Now.AddDays(1))
                {
                    return View("Error", new string[] { "Hosts can only cancel reservations more than one day before the check-in date." });
                }

                // Customers can cancel if the reservation hasn't started
                if (User.IsInRole("Customer") && dbReservation.CheckIn <= DateTime.Now.AddDays(1))
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

            // Handle updates for pending reservations (retain existing functionality for customers)
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
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "You did not provide an ID to delete." });
            }

            var reservation = await _context.Reservations
                                            .Include(r => r.User)
                                            .FirstOrDefaultAsync(r => r.ReservationID == id);

            if (reservation == null)
            {
                return View("Error", new String[] { "There's no reservation with that ID." });
            }

            // Security check: Ensure the reservation belongs to the logged-in user
            if (reservation.User.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to delete this reservation." });
            }

            if (reservation.ReservationStatus == ReservationStatus.Valid)
            {
                return View("Error", new String[] { "You cannot delete a reservation that has been already purchased." });
            }

            if (reservation.ReservationStatus == ReservationStatus.Cancelled)
            {
                return View("Error", new String[] { "You cannot delete a reservation that has already been purchased, even if it's cancelled." });
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations
                                            .Include(r => r.User)
                                            .Include(r => r.Property)
                                            .FirstOrDefaultAsync(r => r.ReservationID == id);

            if (reservation == null)
            {
                return View("Error", new String[] { "The reservation does not exist or has already been deleted." });
            }

            // Security check: Ensure the reservation belongs to the logged-in user
            if (reservation.User.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to delete this reservation." });
            }

            if (reservation.ReservationStatus == ReservationStatus.Valid)
            {
                return View("Error", new String[] { "You cannot delete a reservation that has been already purchased." });
            }

            if (reservation.ReservationStatus == ReservationStatus.Cancelled)
            {
                return View("Error", new String[] { "You cannot delete a reservation that has already been purchased, even if it's cancelled." });
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ShoppingCart));
        }

        [Authorize]
        public async Task<IActionResult> TransactionHistory()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            // Check the user's role
            var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            IQueryable<Reservation> reservationsQuery = _context.Reservations
                .Include(r => r.Property) // Include property details
                .Include(r => r.User);    // Include user details

            // Filter based on role
            if (userRole == "Customer")
            {
                // Customer: Only their reservations
                reservationsQuery = reservationsQuery.Where(r => r.User.Id == user.Id);
            }
            else if (userRole == "Host")
            {
                // Host: Reservations for properties they own
                reservationsQuery = reservationsQuery.Where(r => r.Property.User.Id == user.Id);
            }
            else if (userRole == "Admin")
            {
                // Admin: Can see all reservations (no filtering needed)
            }
            else
            {
                // Unauthorized role
                return View("Error", new string[] { "You are not authorized to view this page." });
            }

            // Fetch the filtered reservations into memory
            var reservations = await reservationsQuery.Where(r => r.ConfirmationNumber != null).ToListAsync();

            // Group the reservations by confirmation number
            var groupedReservations = reservations
                .GroupBy(r => r.ConfirmationNumber)
                .Select(group => new TransactionHistoryViewModel
                {
                    ConfirmationNumber = group.Key.ToString(), // Convert ConfirmationNumber explicitly to string
                    TotalAmount = group.Sum(r =>
                        r.WeekdayTotals +
                        r.WeekendTotals +
                        (r.CleaningFee = r.ReservationStatus == ReservationStatus.Cancelled ? 0 : r.CleaningFee) +
                        r.SalesTax + // Add calculated sales tax
                        r.DiscountAmount // DiscountAmount is already negative
                    ),
                    Reservations = group.ToList() // List of grouped reservations
                })
                .OrderByDescending(group => group.ConfirmationNumber) // Order by ConfirmationNumber descending
                .ToList();

            return View(groupedReservations);
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
        /*
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
        */

        // Checks if the reservation falls on any unavailable dates for the property
        private bool IsReservationOnUnavailableDates(Reservation reservation)
        {
            // Ensure the property exists and has unavailable dates
            if (reservation.Property == null || reservation.Property.UnavailableDates == null || !reservation.Property.UnavailableDates.Any())
            {
                return false;
            }

            // Check if any unavailable date falls within the reservation period
            foreach (var unavailableDate in reservation.Property.UnavailableDates)
            {
                // Check if the unavailable date falls on or within the reservation period
                if (unavailableDate >= reservation.CheckIn && unavailableDate <= reservation.CheckOut)
                {
                    return true; // Conflict found
                }
            }

            return false; // No conflicts
        }


        public async Task<SelectList> GetAllCustomerUserNamesSelectList()
        {
            //create a list to hold the customers
            List<AppUser> allCustomers = new List<AppUser>();

            //See if the user is a customer
            foreach (AppUser dbUser in _context.Users)
            {
                //if the user is a customer, add them to the list of customers
                if (await _userManager.IsInRoleAsync(dbUser, "Customer") == true)
                {
                    allCustomers.Add(dbUser);
                }
            }

            //create a new select list with the customer emails
            SelectList sl = new SelectList(allCustomers.OrderBy(c => c.Email), nameof(AppUser.UserName), nameof(AppUser.Email));

            //return the select list
            return sl;
        }

        public async Task<SelectList> GetShoppingCustomerUserNamesSelectList()
        {
            // Create a list to hold the customers
            List<AppUser> allCustomers = new List<AppUser>();

            // See if the user is a customer
            foreach (AppUser dbUser in _context.Users)
            {
                if (await _userManager.IsInRoleAsync(dbUser, "Customer"))
                {
                    allCustomers.Add(dbUser);
                }
            }

            // Create a new select list with the customer IDs and emails
            SelectList sl = new SelectList(
                allCustomers.OrderBy(c => c.Email),
                nameof(AppUser.Id),
                nameof(AppUser.Email)
            );

            return sl;
        }

        private bool ExistingReservationsAlready(Reservation reservation)
        {
            if (reservation == null || reservation.User == null)
            {
                return false;
            }

            var userReservations = _context.Reservations
                .Where(r => r.User.Id == reservation.User.Id
                            && r.ReservationStatus != ReservationStatus.Cancelled
                            && r.ReservationStatus != ReservationStatus.Pending)
                .ToList();

            foreach (var existingReservation in userReservations)
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

            return false;
        }

    }
}
