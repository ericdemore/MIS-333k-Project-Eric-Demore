using BevoBnB.Models;

namespace BevoBnB.ViewModels
{
    public class ReportViewModel
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalCommission { get; set; }
        public int TotalReservations { get; set; }
        public decimal AverageCommissionPerReservation { get; set; }
        public int TotalProperties { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ZipCode { get; set; }
        public int? CategoryId { get; set; }
        public States? State { get; set; }
        public string? City { get; set; }
        public int? PropertyNumber { get; set; } // New property for PropertyNumber
        public List<Category>? Categories { get; set; }
    }

}
