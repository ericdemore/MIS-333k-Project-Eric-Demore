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
    }
}
