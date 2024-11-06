using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public class Property
    {
        [Key]
        public Int32 PropertyID { get; set; }

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

        //TODO: ADD REST OF ERD ATTRIBUTES PLS


        // navigational properties
        public AppUser User { get; set; }
        public Category Category { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Property()
        {
            if (Reviews == null) 
            { 
                Reviews = new List<Review>(); 
            }
            if (Reservations == null) 
            { 
                Reservations = new List<Reservation>(); 
            }
    }
}
