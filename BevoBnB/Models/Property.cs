﻿using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public enum PropertyState
    {
        Alabama, Alaska, Arizona, Arkansas, California, Colorado, Connecticut, Delaware, Florida, Georgia,
        Hawaii, Idaho, Illinois, Indiana, Iowa, Kansas, Kentucky, Louisiana, Maine, Maryland, Massachusetts,
        Michigan, Minnesota, Mississippi, Missouri, Montana, Nebraska, Nevada, NewHampshire, NewJersey,
        NewMexico, NewYork, NorthCarolina, NorthDakota, Ohio, Oklahoma, Oregon, Pennsylvania, RhodeIsland,
        SouthCarolina, SouthDakota, Tennessee, Texas, Utah, Vermont, Virginia, Washington, WestVirginia,
        Wisconsin, Wyoming
    }
    public class Property
    {
        [Key]
        public Int32 PropertyID { get; set; }

        [Required(ErrorMessage = "Property address is required.")]
        [Display(Name = "Property Address:")]
        [StringLength(100, ErrorMessage = "Property address cannot exceed 100 characters.")]
        public String PropertyAddress { get; set; }

        [Required(ErrorMessage = "Property state is required.")]
        [Display(Name = "Property State:")]
        public PropertyState PropertyState { get; set; }

        [Required(ErrorMessage = "Max guests is required.")]
        [Display(Name = "Max Guests:")]
        [Range(1, 50, ErrorMessage = "Max guests must be between 1 and 50.")]
        public Int32 MaxGuests { get; set; }

        [Required(ErrorMessage = "Number of bedrooms is required.")]
        [Display(Name = "Number of Bedrooms:")]
        [Range(1, 50, ErrorMessage = "Number of bedrooms must be between 1 and 50.")]
        public Int32 NumBedrooms { get; set; }

        [Required(ErrorMessage = "Number of bathrooms is required.")]
        [Display(Name = "Number of Bathrooms:")]
        [Range(1, 50, ErrorMessage = "Number of bathrooms must be between 1 and 50.")]
        public Int32 NumBathrooms { get; set; }

        [Display(Name = "Pets Allowed:")]
        public bool PetsAllowed { get; set; }

        [Display(Name = "Free Parking:")]
        public bool FreeParking { get; set; }

        [Required(ErrorMessage = "Weekday pricing is required.")]
        [Display(Name = "Weekday Pricing:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 100000, ErrorMessage = "Weekday pricing must be between $0 and $100,000.")]
        public Decimal WeekdayPricing { get; set; }

        [Required(ErrorMessage = "Weekend pricing is required.")]
        [Display(Name = "Weekend Pricing:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 10000, ErrorMessage = "Weekend pricing must be between $0 and $100,000.")]
        public Decimal WeekendPricing { get; set; }

        [Required(ErrorMessage = "Cleaning fee is required.")]
        [Display(Name = "Cleaning Fee:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 1000, ErrorMessage = "Cleaning fee must be between $0 and $1,000.")]
        public Decimal CleaningFee { get; set; }

        [Required(ErrorMessage = "Minimum nights for discount is required.")]
        [Display(Name = "Discount Minimum Nights:")]
        [Range(1, 30, ErrorMessage = "Minimum nights for discount must be between 1 and 30.")]
        public Int32 DiscountMinNights { get; set; }

        [Required(ErrorMessage = "Discount percentage is required.")]
        [Display(Name = "Discount Percentage:")]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0% and 100%.")]
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public Decimal DiscountPercent { get; set; }

        [Display(Name = "Property Status (Active):")]
        public bool PropertyStatus { get; set; }
    }
}
