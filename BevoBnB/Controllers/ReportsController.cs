using BevoBnB.DAL;
using BevoBnB.Models;
using BevoBnB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BevoBnB.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var viewModel = new ReportViewModel
            {
                Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DateTime? startDate, DateTime? endDate, string? zipCode, int? categoryId, States? state, string? city, int? propertyNumber)
        {
            if (endDate.HasValue && startDate.HasValue && endDate < startDate)
            {
                ModelState.AddModelError("", "End date must be after the start date.");
            }

            var reservations = _context.Reservations
                .Include(r => r.Property)
                .Where(r => r.ReservationStatus == ReservationStatus.Valid);

            if (startDate.HasValue)
            {
                reservations = reservations.Where(r => r.CheckOut >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                reservations = reservations.Where(r => r.CheckIn <= endDate.Value);
            }

            if (!string.IsNullOrWhiteSpace(zipCode))
            {
                reservations = reservations.Where(r => r.Property.ZipCode == zipCode);
            }

            if (categoryId.HasValue)
            {
                reservations = reservations.Where(r => r.Property.CategoryId == categoryId.Value);
            }

            if (state.HasValue)
            {
                reservations = reservations.Where(r => r.Property.State == state.Value);
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                reservations = reservations.Where(r => r.Property.City.ToLower() == city.ToLower());
            }

            if (propertyNumber.HasValue)
            {
                reservations = reservations.Where(r => r.Property.PropertyNumber == propertyNumber.Value);
            }

            var reservationsList = reservations.ToList();

            var totalRevenue = reservationsList.Sum(r => r.StayTotal);
            var totalCommission = totalRevenue * 0.10m;
            var totalReservations = reservationsList.Count;
            var averageCommissionPerReservation = totalReservations > 0
                ? totalCommission / totalReservations
                : 0;

            var totalProperties = reservationsList
                .Where(r => r.Property != null)
                .Select(r => r.Property.PropertyNumber)
                .Distinct()
                .Count();

            var reportViewModel = new ReportViewModel
            {
                TotalRevenue = totalRevenue,
                TotalCommission = totalCommission,
                TotalReservations = totalReservations,
                AverageCommissionPerReservation = averageCommissionPerReservation,
                TotalProperties = totalProperties,
                StartDate = startDate,
                EndDate = endDate,
                ZipCode = zipCode,
                CategoryId = categoryId,
                State = state,
                City = city,
                PropertyNumber = propertyNumber,
                Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList(),
                SearchPerformed = true
            };

            return View("Details", reportViewModel);
        }



        [Authorize(Roles = "Host")]
        public IActionResult HostReport()
        {
            var viewModel = new HostReportViewModel
            {
                Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Host")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HostReport(DateTime? startDate, DateTime? endDate, string? zipCode, int? categoryId, States? state, string? city)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // First, fetch all the relevant reservations
            var reservations = _context.Reservations
                .Include(r => r.Property)
                .ThenInclude(p => p.User)
                .Where(r => r.Property.User.Id == userId &&
                           r.ReservationStatus == ReservationStatus.Valid)
                .AsNoTracking();  // Add this for better performance since we're just reading

            if (startDate.HasValue)
            {
                reservations = reservations.Where(r => r.CheckOut >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                reservations = reservations.Where(r => r.CheckIn <= endDate.Value);
            }
            if (!string.IsNullOrWhiteSpace(zipCode))
            {
                reservations = reservations.Where(r => r.Property.ZipCode == zipCode);
            }
            if (categoryId.HasValue)
            {
                reservations = reservations.Where(r => r.Property.CategoryId == categoryId.Value);
            }
            if (state.HasValue)
            {
                reservations = reservations.Where(r => r.Property.State == state.Value);
            }
            if (!string.IsNullOrWhiteSpace(city))
            {
                reservations = reservations.Where(r => r.Property.City.ToLower() == city.ToLower());
            }

            // Materialize the query and perform grouping in memory
            var reservationsList = reservations.ToList();

            var propertyDetails = reservationsList
                .GroupBy(r => new { r.Property.PropertyID, r.Property.StreetAddress })
                .Select(g => new PropertyReportDetail
                {
                    PropertyID = g.Key.PropertyID,
                    PropertyName = g.Key.StreetAddress,
                    TotalStayRevenue = g.Sum(r => r.StayTotal),
                    TotalCleaningFees = g.Sum(r => r.CleaningFee),
                    CompletedReservations = g.Count()
                })
                .ToList();

            // Calculate the total number of properties with reservations in the date range
            var propertiesWithReservations = reservationsList
                .Select(r => r.Property.PropertyID)
                .Distinct()
                .Count();

            var viewModel = new HostReportViewModel
            {
                StartDate = startDate,
                EndDate = endDate,
                ZipCode = zipCode,
                CategoryId = categoryId,
                State = state,
                City = city,
                Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList(),
                PropertyDetails = propertyDetails,
                PropertiesWithReservations = propertiesWithReservations,
                SearchPerformed = true
            };

            return View(viewModel);
        }
    }
}
