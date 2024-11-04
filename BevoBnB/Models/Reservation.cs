using Azure.Identity;

namespace BevoBnB.Models
{
    public class Reservation
    {
        public string PropertyID { get; set; }


        public int HostID { get; set; }
        public int CategoryID { get; set; } 



        public Int32 PropertyNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }   
        public string Zip {  get; set; }
        public Int32 Bedrooms { get; set; }
        public Int32 Bathrooms { get; set; }
        public Int32 GuestsAllowed { get; set; }
        public Int32 PetsAllowed { get; set; }
        public Boolean FreeParking { get; set; }
        public Int32 WeekdayPrice { get; set; }
        public Int32 WeekendPrice { get; set; }
        public Int32 CleaningPrice { get; set; }
        public Decimal? DiscountRate { get; set; }
        public Int32 MinNightsForDiscount { get; set; }
        public Boolean UnavaiableDates { get; set; }           
        public string PropertyStatus { get; set; }


    }
}
