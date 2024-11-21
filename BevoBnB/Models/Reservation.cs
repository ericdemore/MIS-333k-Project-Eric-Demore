using System;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public enum ReservationStatus { Valid, Cancelled }

    public class Reservation
    {
        [Key]
        [Display(Name = "Reservation ID")]
        public Int32 ReservationID { get; set; }

        [Required(ErrorMessage = "Please provide the check-in date and time.")]
        [Display(Name = "Check-In Date and Time")]
        [DataType(DataType.DateTime)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Please provide the check-out date and time.")]
        [Display(Name = "Check-Out Date and Time")]
        [DataType(DataType.DateTime)]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "The total number of guests must be specified.")]
        [Range(1, int.MaxValue, ErrorMessage = "The number of guests must be at least 1.")]
        [Display(Name = "Number of Guests (including person making reservation)")]
        public Int32 NumOfGuests { get; set; }

        [Required(ErrorMessage = "Please provide the weekday price for the reservation.")]
        [Display(Name = "Weekday Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal WeekdayPrice { get; set; }

        [Required(ErrorMessage = "Please provide the weekend price for the reservation.")]
        [Display(Name = "Weekend Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal WeekendPrice { get; set; }

        [Display(Name = "Discount Rate")]
        [Range(0.0, 1.0, ErrorMessage = "The discount rate must be a decimal value between 0.0 (no discount) and 1.0 (100% discount).")]
        public Decimal DiscountRate { get; set; }

        [Display(Name = "Tax Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Tax { get; set; }

        [Display(Name = "Confirmation Number")]
        public Int32 ConfirmationNumber { get; set; }

        [Display(Name = "Reservation Status")]
        public ReservationStatus ReservationStatus { get; set; }


        // scalar properties for relationships
        public AppUser User { get; set; }
        public Property Property { get; set; }


        // private constants
        private const Decimal TAX_RATE = 0.0825m;
    }
}

