using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BevoBnB.Models
{
    public enum States
    {
        AL, CO, HI, KS, MA, MT, NM, OK, SD, VA,
        AK, CT, ID, KY, MI, NE, NY, OR, TN, WA,
        AZ, DE, IL, LA, MN, NV, NC, PA, TX, WV,
        AR, FL, IN, ME, MS, NH, ND, RI, UT, WI,
        CA, GA, IA, MD, MO, NJ, OH, SC, VT, WY,
        DC
    }
    public enum PropertyStatus { Approved, Unapproved, Inactive }

    public class Property
    {
        [Key]
        [Display(Name = "Property ID")]
        public int PropertyID { get; set; }

        [Display(Name = "Property Number")]
        public int PropertyNumber { get; set; }

        [Required(ErrorMessage = "Address Line 1 must be provided.")]
        [Display(Name = "Primary Address Line")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required. Please enter the city name.")]
        [Display(Name = "City Name")]
        public string City { get; set; }

        [Required(ErrorMessage = "State selection is required.")]
        [Display(Name = "State")]
        public States State { get; set; }

        [Required(ErrorMessage = "A valid ZIP code must be provided.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "ZIP code format is invalid. Use 12345 or 12345-6789.")]
        [Display(Name = "Postal Code (ZIP)")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "The number of bedrooms is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The number of bedrooms must be at least 1.")]
        [Display(Name = "Number of Bedrooms")]
        public int Bedrooms { get; set; }

        [Required(ErrorMessage = "The number of bathrooms is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The number of bathrooms must be at least 1.")]
        [Display(Name = "Number of Bathrooms")]
        public int Bathrooms { get; set; }

        [Required(ErrorMessage = "The maximum number of guests allowed must be specified.")]
        [Range(1, int.MaxValue, ErrorMessage = "The number of guests must be at least 1.")]
        [Display(Name = "Maximum Guests Allowed")]
        public int GuestsAllowed { get; set; }

        [Display(Name = "Are Pets Allowed?")]
        public bool PetsAllowed { get; set; }

        [Display(Name = "Is Free Parking Available?")]
        public bool FreeParking { get; set; }

        [Required(ErrorMessage = "The weekday pricing must be provided.")]
        [Range(0, double.MaxValue, ErrorMessage = "The weekday price must be a positive value.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Weekday Price Per Night")]
        public decimal WeekdayPricing { get; set; }

        [Required(ErrorMessage = "The weekend pricing must be provided.")]
        [Range(0, double.MaxValue, ErrorMessage = "The weekend price must be a positive value.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Weekend Price Per Night")]
        public decimal WeekendPricing { get; set; }

        [Required(ErrorMessage = "The cleaning fee must be provided.")]
        [Range(0, double.MaxValue, ErrorMessage = "The cleaning fee must be a positive value.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Cleaning Fee")]
        public decimal CleaningFee { get; set; }

        [Range(0, 1, ErrorMessage = "The discount rate must be between 0 (0%) and 1 (100%).")]
        [Display(Name = "Discount Rate (%)")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal? DiscountRate { get; set; }

        [Display(Name = "Minimum Nights Required for Discount")]
        [Range(1, int.MaxValue, ErrorMessage = "The mininum number of nights for a discount must be greater than 1")]
        public int? MinNightsforDiscount { get; set; }

        [Required(ErrorMessage = "A list of unavailable dates is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Unavailable Dates (Blocked)")]
        public List<DateTime> UnavailableDates { get; set; }

        [Required(ErrorMessage = "The status of the property must be specified.")]
        [Display(Name = "Current Property Status")]
        public PropertyStatus PropertyStatus { get; set; }

        // Added Property
        [Display(Name = "Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; } // Foreign key to reference Category

        // Navigational properties
        public AppUser User { get; set; }
        public Category Category { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Reservation> Reservations { get; set; }

        // Constructor for null references/prevent them
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

        // read only properties (not in db Schema)
        [Display(Name = "Average Rating")]
        public decimal AverageRating
        {
            get { return CalculateAvgRating(); }
        }

        // methods

        private decimal CalculateAvgRating()
        {
            if (Reviews == null || Reviews.Any() == false)
            {
                return 0;
            }

            return (int)Math.Round(Reviews.Average(p => p.Rating), 1);
        }
    }
}
