using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public enum PropertyStatus
{
    Available,
    Pending,
    Booked
}


public class Property
{
    [Key]
    public string PropertyID { get; set; } // Primary key, auto-generated ID

    [ForeignKey("AppUser")]
    public int HostID { get; set; } // Foreign key for Host

    [ForeignKey("Category")]
    public int CategoryID { get; set; } // Foreign key for Category



    [Required(ErrorMessage = "Property Number is required.")]
    [Display(Name = "Property Number:")]
    [Range(1, int.MaxValue, ErrorMessage = "Property Number must be greater than zero.")]
    public Int32 PropertyNumber { get; set; } // Unique property identifier number



    [Required(ErrorMessage = "Street Name is required.")]
    [Display(Name = "Street Name:")]
    [StringLength(50, ErrorMessage = "Street Name cannot exceed 50 characters.")]
    public string Street { get; set; } // Street address with a maximum length of 50 characters



    [Required(ErrorMessage = "City is required.")]
    [Display(Name = "City:")]
    [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
    public string City { get; set; } // City name, up to 50 characters



    [Required(ErrorMessage = "State is required.")]
    [Display(Name = "State:")]
    [StringLength(50, ErrorMessage = "State cannot exceed 50 characters.")]
    public string State { get; set; } // State name or abbreviation, up to 50 characters



    [Required(ErrorMessage = "Zip Code is required.")]
    [Display(Name = "Zip Code:")]
    [StringLength(10, MinimumLength = 5, ErrorMessage = "Zip code should be between 5 and 10 characters.")]
    public string Zip { get; set; } // Zip code with minimum and maximum length



    [Required(ErrorMessage = "Number of Bedrooms is required.")]
    [Display(Name = "Bedrooms:")]
    [Range(1, 10, ErrorMessage = "Bedrooms must be between 1 and 10.")]
    public Int32 Bedrooms { get; set; } // Number of bedrooms



    [Required(ErrorMessage = "Number of Bathrooms is required.")]
    [Display(Name = "Bathrooms:")]
    [Range(1, 10, ErrorMessage = "Bathrooms must be between 1 and 10.")]
    public Int32 Bathrooms { get; set; } // Number of bathrooms



    [Required(ErrorMessage = "Guests Allowed is required.")]
    [Display(Name = "Guests Allowed:")]
    [Range(1, 100, ErrorMessage = "Guests allowed must be between 1 and 100.")]
    public Int32 GuestsAllowed { get; set; } // Number of guests allowed



    [Required(ErrorMessage = "Pets Allowed is required.")]
    [Display(Name = "Pets Allowed:")]
    public Int32 PetsAllowed { get; set; } // Number of pets allowed, may vary based on property policy



    [Required(ErrorMessage = "Free Parking information is required.")]
    [Display(Name = "Free Parking:")]
    public Boolean FreeParking { get; set; } // Indicates if free parking is available



    [Required(ErrorMessage = "Weekday Price is required.")]
    [Display(Name = "Weekday Price:")]
    [Range(0, double.MaxValue, ErrorMessage = "Weekday price must be a positive value.")]
    public Int32 WeekdayPrice { get; set; } // Price per night on weekdays



    [Required(ErrorMessage = "Weekend Price is required.")]
    [Display(Name = "Weekend Price:")]
    [Range(0, double.MaxValue, ErrorMessage = "Weekend price must be a positive value.")]
    public Int32 WeekendPrice { get; set; } // Price per night on weekends



    [Required(ErrorMessage = "Cleaning Price is required.")]
    [Display(Name = "Cleaning Price:")]
    [Range(0, double.MaxValue, ErrorMessage = "Cleaning price must be a positive value.")]
    public Int32 CleaningPrice { get; set; } // One-time cleaning fee per booking



    [Display(Name = "Discount Rate:")]
    [Range(0, 1, ErrorMessage = "Discount rate must be between 0 and 1 (representing a percentage).")]
    public Decimal? DiscountRate { get; set; } // Discount rate, optional, as a decimal (e.g., 0.10 for 10%)



    [Display(Name = "Minimum Nights for Discount:")]
    [Range(1, 365, ErrorMessage = "Minimum nights for discount must be between 1 and 365.")]
    public Int32 MinNightsForDiscount { get; set; } // Minimum nights to qualify for a discount



    [Display(Name = "Unavailable Dates:")]
    public Boolean UnavailableDates { get; set; } // Boolean flag or could be a complex type for date range management



    [Display(Name = "Property Status:")]
    public PropertyStatus PropertyStatus { get; set; } // Enum indicating status (e.g., Available, Pending, Booked)
}
