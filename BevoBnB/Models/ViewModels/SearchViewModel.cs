using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public class ProfileSearchViewModel
    {
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
    }

    // for property search
    public enum PSVMRange { GreaterThan, LessThan}

    public class PropertySearchViewModel
    {

        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "State")]
        public States? State { get; set; }

        [Display(Name = "Guest Rating")]
        [Range(1, 5, ErrorMessage = "Guest Rating must be between 1 and 5.")]
        public decimal? GuestRating { get; set; }

        public PSVMRange? GuestRatingRange { get; set; }

        [Display(Name = "Maximum Guests")]
        [Range(1, int.MaxValue, ErrorMessage = "Maximum Guests must be at least 1.")]
        public int? MaxGuests { get; set; }

        public PSVMRange? MaxGuestsRange { get; set; }

        [Display(Name = "Bedrooms")]
        [Range(0, int.MaxValue, ErrorMessage = "Bedrooms must be a non-negative number.")]
        public int? Bedrooms { get; set; }

        public PSVMRange? BedroomsRange { get; set; }

        [Display(Name = "Bathrooms")]
        [Range(0, int.MaxValue, ErrorMessage = "Bathrooms must be a non-negative number.")]
        public int? Bathrooms { get; set; }

        public PSVMRange? BathroomsRange { get; set; }

        [Display(Name = "Pets Allowed")]
        public bool? PetsAllowed { get; set; }

        [Display(Name = "Free Parking")]
        public bool? FreeParking { get; set; }

        [Display(Name = "Min Weekday Pricing")]
        [Range(0, double.MaxValue, ErrorMessage = "Minimum Weekday Pricing must be a non-negative number.")]
        public decimal? MinWeekdayPricing { get; set; }

        [Display(Name = "Max Weekday Pricing")]
        [Range(0, double.MaxValue, ErrorMessage = "Maximum Weekday Pricing must be a non-negative number.")]
        public decimal? MaxWeekdayPricing { get; set; }

        [Display(Name = "Min Weekend Pricing")]
        [Range(0, double.MaxValue, ErrorMessage = "Minimum Weekend Pricing must be a non-negative number.")]
        public decimal? MinWeekendPricing { get; set; }

        [Display(Name = "Max Weekend Pricing")]
        [Range(0, double.MaxValue, ErrorMessage = "Maximum Weekend Pricing must be a non-negative number.")]
        public decimal? MaxWeekendPricing { get; set; }

        [Display(Name = "Category")]
        public int? Category { get; set; }

        [Display(Name = "Check-In Date")]
        [DataType(DataType.Date)]
        public DateTime? CheckIn { get; set; }

        [Display(Name = "Check-Out Date")]
        [DataType(DataType.Date)]
        public DateTime? CheckOut { get; set; }

        [Display(Name = "Search by Dates")]
        public bool? DateTypeSearch { get; set; }
    }
}
