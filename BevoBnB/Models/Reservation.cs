using System;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public enum ReservationStatus { Valid, Cancelled, Pending }

    public class Reservation
    {
        [Key]
        [Display(Name = "Reservation ID")]
        public int ReservationID { get; set; }

        [Display(Name = "Check-In Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check-Out Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime CheckOut { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The number of guests must be at least 1.")]
        [Display(Name = "Number of Guests")]
        public int NumOfGuests { get; set; }

        [Display(Name = "Weekday Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal WeekdayPrice { get; set; }

        [Display(Name = "Weekend Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal WeekendPrice { get; set; }

        [Display(Name = "Cleaning Fee")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal CleaningFee { get; set; }

        [Display(Name = "Discount Rate")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal? DiscountRate { get; set; }

        [Display(Name = "Tax Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Tax { get; set; }

        [Display(Name = "Confirmation Number")]
        public int? ConfirmationNumber { get; set; }

        [Display(Name = "Reservation Status")]
        public ReservationStatus ReservationStatus { get; set; }


        // scalar properties for relationships
        public AppUser User { get; set; }
        public Property Property { get; set; }


        // private constants
        private const Decimal TAX_RATE = 0.07m;


        // read only properties
        [Display(Name = "Number of Weekday Nights")]
        public int NumOfWeekdays
        {
            get { return CalculateNumberOfWeekdays(); }
        }

        [Display(Name = "Number of Weekend Nights")]
        public int NumOfWeekends
        {
            get { return CalculateNumberOfWeekends(); }
        }

        public int TotalNights
        {
            get { return NumOfWeekdays + NumOfWeekends; }
        }

        [Display(Name = "Weekday Totals")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal WeekdayTotals
        {
            get { return CalculateWeekdayTotals(); }
        }

        [Display(Name = "Weekend Totals")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal WeekendTotals
        {
            get { return CalculateWeekendTotals(); }
        }

        [Display(Name = "Stay Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal StayTotal
        {
            get { return WeekdayTotals + WeekendTotals; }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal StayPrice
        {
            get { return CalculateStayPrice(); }
        }

        [Display(Name = "Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Subtotal
        {
            get { return CalculateSubtotals(); }
        }

        [Display(Name = "Discount Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DiscountAmount 
        { 
            get { return CalculateDiscount(); } 
        }

        [Display(Name = "Sales Tax")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SalesTax
        {
            get { return CalculateSalesTax(); }
        }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Total
        {
            get { return CalculateTotals(); }
        }

        // methods for reservations
        private decimal CalculateWeekdayTotals()
        {
            if (ReservationStatus == ReservationStatus.Cancelled)
            {
                return 0.00m;
            }

            int numberOfWeekdays = CalculateNumberOfWeekdays();

            return numberOfWeekdays * WeekdayPrice;
        }

        private decimal CalculateWeekendTotals()
        {
            if (ReservationStatus == ReservationStatus.Cancelled)
            {
                return 0.00m;
            }

            int numberOfWeekends = CalculateNumberOfWeekends();

            return numberOfWeekends * WeekendPrice;
        }

        private decimal CalculateSubtotals()
        {
            decimal totalSubtotal = 0.00m;

            if (ReservationStatus == ReservationStatus.Cancelled)
            {
                return 0.00m;
            }

            totalSubtotal = StayPrice + CleaningFee;

            return totalSubtotal;
        }

        private decimal CalculateStayPrice()
        {
            decimal stayPrice = 0.00m;

            if (ReservationStatus == ReservationStatus.Cancelled)
            {
                return 0.00m;
            }

            stayPrice = (WeekdayTotals + WeekendTotals) + DiscountAmount;

            return stayPrice;
        }

        private decimal CalculateDiscount()
        {
            decimal discountAmount = 0.00m;
            decimal discountRate = DiscountRate == null ? 0.00m : DiscountRate.Value; // cannot use the DiscountRate if it's null, so turn

            if (ReservationStatus == ReservationStatus.Cancelled)
            {
                return 0.00m;
            }

            discountAmount = ((WeekdayTotals + WeekendTotals) * discountRate) * -1.00m;

            return discountAmount;
        }

        private decimal CalculateSalesTax()
        {
            decimal salesTax = 0.00m;

            if (ReservationStatus == ReservationStatus.Cancelled)
            {
                return 0.00m;
            }

            salesTax = Subtotal * TAX_RATE;

            return salesTax;
        }

        private decimal CalculateTotals()
        {
            decimal totalAmount = 0.00m;

            if (ReservationStatus == ReservationStatus.Cancelled)
            {
                return 0.00m;
            }

            if (CheckIn < DateTime.Now)
            {
                return 0.00m;
            }

            totalAmount = Subtotal + SalesTax;

            return totalAmount;
        }

        private int CalculateNumberOfWeekdays()
        {
            int weekdayCount = 0;
            DateTime currentDate = CheckIn;

            if (ReservationStatus == ReservationStatus.Cancelled)
            {
                return 0;
            }

            while (currentDate < CheckOut)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Friday && currentDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    weekdayCount = weekdayCount + 1;
                }
                currentDate = currentDate.AddDays(1);
            }

            return weekdayCount;
        }

        private int CalculateNumberOfWeekends()
        {
            int weekendCount = 0;
            DateTime currentDate = CheckIn;

            if (ReservationStatus == ReservationStatus.Cancelled)
            {
                return 0;
            }

            while (currentDate < CheckOut)
            {
                if (currentDate.DayOfWeek == DayOfWeek.Friday || currentDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    weekendCount = weekendCount + 1;
                }
                currentDate = currentDate.AddDays(1);
            }

            return weekendCount;
        }
    }
}

