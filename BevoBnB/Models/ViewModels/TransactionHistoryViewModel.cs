using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public class TransactionHistoryViewModel
    {
        [Display(Name = "Confirmation No.")]
        public string ConfirmationNumber { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Reservations")]
        public List<Reservation> Reservations { get; set; }
    }
}
