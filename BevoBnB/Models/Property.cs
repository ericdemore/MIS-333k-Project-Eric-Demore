namespace BevoBnB.Models
{
    public class Property
    {
        public Int32 PropertyID { get; set; }
        //test comment
        public Int32 PropertyNumber { get; set; }

        public String LineAddress1 { get; set; }

        public String LineAddress2 { get; set; }

        public String City { get; set; }

        public States State { get; set; }

        public String ZipCode { get; set; }

        public Int32 Bedrooms { get; set; }

        public Decimal Bathrooms { get; set; }

        public Int32 GuestsAllowed { get; set; }

        public Boolean PetsAllowed { get; set; }

        public Boolean FreeParking { get; set; }
    }
}
