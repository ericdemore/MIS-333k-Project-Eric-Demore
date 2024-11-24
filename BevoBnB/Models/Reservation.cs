using System;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public enum ReservationStatus { Valid, Cancelled }

    public class Reservation
    {
        [Key]
        [Display(Name = "Reservation ID")]
        public int ReservationID { get; set; }

        [Required(ErrorMessage = "Please provide the check-in date.")]
        [Display(Name = "Check-In Date")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Please provide the check-out date.")]
        [Display(Name = "Check-Out Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "The total number of guests must be specified.")]
        [Range(1, int.MaxValue, ErrorMessage = "The number of guests must be at least 1.")]
        [Display(Name = "Number of Guests (including person making reservation)")]
        public int NumOfGuests { get; set; }

        [Display(Name = "Weekday Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal WeekdayPrice { get; set; }

        [Display(Name = "Weekend Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal WeekendPrice { get; set; }

        [Display(Name = "Cleaning Fee")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? CleaningFee { get; set; }

        [Display(Name = "Discount Rate")]
        public decimal? DiscountRate { get; set; }

        [Display(Name = "Tax Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Tax { get; set; }

        [Display(Name = "Confirmation Number")]
        public int ConfirmationNumber { get; set; }

        [Display(Name = "Reservation Status")]
        public ReservationStatus ReservationStatus { get; set; }


        // scalar properties for relationships
        public AppUser User { get; set; }
        public Property Property { get; set; }


        // private constants
        private const Decimal TAX_RATE = 0.07m;
    }
}

