namespace BevoBnB.Models
{
    public class ReservationDetails
    {
        public Int32 ReservationDetailsID { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public Int32 NumGuests { get; set; }

        public Decimal Price { get; set; }

        public Decimal CleaningFee { get; set; }

        public Decimal DiscountApplied { get; set; }
    }
}
