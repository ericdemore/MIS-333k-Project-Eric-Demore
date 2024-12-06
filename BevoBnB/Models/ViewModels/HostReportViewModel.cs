using BevoBnB.Models;

namespace BevoBnB.ViewModels
{
    public class HostReportViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ZipCode { get; set; }
        public int? CategoryId { get; set; }
        public States? State { get; set; }
        public string? City { get; set; }
        public List<Category> Categories { get; set; } = new();
        public List<PropertyReportDetail> PropertyDetails { get; set; } = new();
        public decimal TotalHostRevenue => PropertyDetails.Sum(p => p.TotalHostRevenue);
        public decimal TotalCleaningFees => PropertyDetails.Sum(p => p.TotalCleaningFees);
        public decimal GrandTotal => TotalHostRevenue + TotalCleaningFees;
        public int TotalCompletedReservations => PropertyDetails.Sum(p => p.CompletedReservations);
        public int PropertiesWithReservations { get; set; }
    }

    public class PropertyReportDetail
    {
        public int PropertyID { get; set; }
        public string PropertyName { get; set; }
        public decimal TotalStayRevenue { get; set; }
        public decimal TotalHostRevenue => TotalStayRevenue * 0.9m; // Host gets 90% of stay revenue
        public decimal TotalCleaningFees { get; set; }
        public decimal PropertyTotal => TotalHostRevenue + TotalCleaningFees;
        public int CompletedReservations { get; set; }
    }
}
