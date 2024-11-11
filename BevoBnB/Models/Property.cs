using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BevoBnB.Models
{
    public enum PropertyStatus { Unpublished, Published, Removed }

    public class Property
    {
        [Key]
        [Display(Name = "Property ID")]
        public Int32 PropertyID { get; set; }

        [Required(ErrorMessage = "Property Number is required.")]
        public Int32 PropertyNumber { get; set; }

        [Required(ErrorMessage = "Address Line 1 is required.")]
        [Display(Name = "Address Line 1")]
        public String LineAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        public String? LineAddress2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public States State { get; set; }

        [Required(ErrorMessage = "A postal code is required.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid postal code format. Use 12345 or 12345-6789.")]
        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        [Required(ErrorMessage = "Number of Bedrooms is required.")]
        [Display(Name = "Bedrooms")]
        public Int32 Bedrooms { get; set; }

        [Required(ErrorMessage = "Number of Bathrooms is required.")]
        [Display(Name = "Bathrooms")]
        public Decimal Bathrooms { get; set; }

        [Required(ErrorMessage = "Number of Guests Allowed is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Guests Allowed must be between 1 and 100.")] //QUESTION: does this need to include the person making the reservation?
        [Display(Name = "Guests Allowed")]
        public Int32 GuestsAllowed { get; set; }

        [Display(Name = "Pets Allowed")]
        public Boolean PetsAllowed { get; set; }

        [Display(Name = "Free Parking")]
        public Boolean FreeParking { get; set; }

        [Required(ErrorMessage = "Weekday Pricing is required.")]
        [Range(0, 999999999, ErrorMessage = "Weekday Pricing must be a positive value.")]
        [DisplayFormat(DataFormatString = "{0:C3}")]
        [Display(Name = "Weekday Pricing")]
        public Decimal WeekdayPricing { get; set; }

        [Required(ErrorMessage = "Weekend Pricing is required.")]
        [Range(0, 999999999, ErrorMessage = "Weekend Pricing must be a positive value.")]
        [DisplayFormat(DataFormatString = "{0:C3}")]
        [Display(Name = "Weekend Pricing")]
        public Decimal WeekendPricing { get; set; }

        [Required(ErrorMessage = "Cleaning Fee is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Cleaning Fee must be a positive value.")]
        [DisplayFormat(DataFormatString = "{0:C3}")]
        [Display(Name = "Cleaning Fee")]
        public Decimal CleaningFee { get; set; }

        [Range(0, 1, ErrorMessage = "Discount Rate must be between 0 and 1.")]
        [Display(Name = "Discount Rate")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public Decimal DiscountRate { get; set; }

        [Display(Name = "Minimum Nights for Discount")]
        public Int32 MinNightsforDiscount { get; set; }

        //NOTE: we will be using a list object for datetimes that are no good
        [Required(ErrorMessage = "Unavailable Dates are required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Unavailable Dates")]
        public List<DateTime> UnavailableDates { get; set; }

        [Required(ErrorMessage = "Property Status is required.")]
        [Display(Name = "Property Status")]
        public PropertyStatus PropertyStatus { get; set; }


        // navigational properties
        public AppUser User { get; set; }
        public Category Category { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Reservation> Reservations { get; set; }


        // constructor for null references/prevent them
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


        //TODO: add method to check whether the property is reserved
        public Boolean IsReserved(Property property)
        {
            return true;
        }
    }
}
