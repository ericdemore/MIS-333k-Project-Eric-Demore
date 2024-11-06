using System;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public enum ReservationStatus { Pending, Confirmed, Cancelled, Completed }

    public class Reservation
    {
        private const Decimal TAX_RATE = 0.0825m;

        [Key]
        [Display(Name = "Reservation ID")]
        public Int32 ReservationID { get; set; }

        [Required(ErrorMessage = "Check-in date and time are required.")]
        [Display(Name = "Check-In Date and Time")]
        [DataType(DataType.DateTime)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Check-out date and time are required.")]
        [Display(Name = "Check-Out Date and Time")]
        [DataType(DataType.DateTime)]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "Number of guests is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of guests must be be a positive number.")]
        [Display(Name = "Number of Guests (including person making reservation)")] //Note: Need to ask jawad about this
        public Int32 NumOfGuests { get; set; }

        [Required(ErrorMessage = "Weekday price is required.")]
        [Display(Name = "Weekday Price")]
        public Decimal WeekdayPrice { get; set; }

        [Required(ErrorMessage = "Weekend price is required.")]
        [Display(Name = "Weekend Price")]
        public Decimal WeekendPrice { get; set; }

        [Display(Name = "Discount Rate")]
        [Range(0.0, 1.0, ErrorMessage = "Discount rate must be between 0.0 and 1.0.")]
        public Decimal DiscountRate { get; set; }

        [Display(Name = "Tax Amount")]
        public Decimal Tax { get; set; }

        [Display(Name = "Confirmation Number")]
        public Int32 ConfirmationNumber { get; set; }

        [Required]
        [Display(Name = "Reservation Status")]
        public ReservationStatus ReservationStatus { get; set; }

        public AppUser User { get; set; }
        public Property Property { get; set; }
    }
}

