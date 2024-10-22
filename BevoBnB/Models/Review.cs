using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public enum ReviewStatus
    {
        Verified,
        [Display(Name = "Under Dispute")]
        Disputed,
        Removed
    }

    public class Review
    {
        [Key]
        public Int32 ReviewID { get; set; }

        [Required(ErrorMessage = "Review date is required.")]
        [Display(Name = "Review Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReviewDate { get; set; }

        [Required(ErrorMessage = "Review rating is required.")]
        [Display(Name = "Review Rating:")]
        [Range(0.0, 5.0, ErrorMessage = "Rating must be between 0.0 and 5.0.")]
        public Decimal ReviewRating { get; set; }

        [Required(ErrorMessage = "Review text is required.")]
        [Display(Name = "Review Text:")]
        [StringLength(1000, ErrorMessage = "Review text cannot exceed 1000 characters.")]
        public String ReviewText { get; set; }

        [Display(Name = "Review Status:")]
        public ReviewStatus? ReviewStatus { get; set; }  // Nullable to allow no status if needed

        [Display(Name = "Dispute Reasoning:")]
        [StringLength(500, ErrorMessage = "Dispute reasoning cannot exceed 500 characters.")]
        public String? DisputeReasoning { get; set; }
    }
}
