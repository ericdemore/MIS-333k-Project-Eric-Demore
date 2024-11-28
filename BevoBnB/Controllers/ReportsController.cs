using BevoBnB.DAL;
using BevoBnB.Models;
using BevoBnB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BevoBnB.Controllers
{
    [Authorize(Roles = "Admin")] // Restrict access to Admin role
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        // Display the form to generate a report
        public IActionResult Create()
        {
            return View();
        }

        // Generate the report based on the provided date range
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DateTime startDate, DateTime endDate)
        {
            // Ensure the date range is valid
            if (endDate < startDate)
            {
                ModelState.AddModelError("", "End date must be after the start date.");
                return View();
            }

            // Query reservations within the date range
            var reservations = _context.Reservations
                .Include(r => r.Property) // Ensure Property is loaded
                .Where(r => r.ReservationStatus == ReservationStatus.Valid &&
                            r.CheckIn <= endDate && r.CheckOut >= startDate)
                .ToList();

            // Calculate metrics
            var totalRevenue = reservations.Sum(r => r.StayTotal);
            var totalCommission = totalRevenue * 0.10m; // BevoBnB earns 10% commission
            var totalReservations = reservations.Count;
            var averageCommissionPerReservation = totalReservations > 0
                ? totalCommission / totalReservations
                : 0;

            // Count distinct properties, ensuring Property is not null
            var totalProperties = reservations
                .Where(r => r.Property != null) // Exclude null Properties
                .Select(r => r.Property.PropertyNumber)
                .Distinct()
                .Count();

            // Populate the ViewModel
            var reportViewModel = new ReportViewModel
            {
                TotalRevenue = totalRevenue,
                TotalCommission = totalCommission,
                TotalReservations = totalReservations,
                AverageCommissionPerReservation = averageCommissionPerReservation,
                TotalProperties = totalProperties,
                StartDate = startDate,
                EndDate = endDate
            };

            return View("Details", reportViewModel);
        }
    }
}
