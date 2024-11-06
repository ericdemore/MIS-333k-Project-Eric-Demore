using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BevoBnB.Models
{
    public enum DisputeStatus { Disputed, Resolved }

    public class Review
    {
        [Key]
        [Display(Name = "Review ID")]
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(0.0, 5.0, ErrorMessage = "Rating must be between 1.0 and 5.0.")]
        [Display(Name = "Rating")]
        public decimal Rating { get; set; }

        [Display(Name = "Review Text")]
        [StringLength(1000, ErrorMessage = "Review text cannot exceed 1000 characters.")]
        public string ReviewText { get; set; }

        [Display(Name = "Host Comments")]
        [StringLength(1000, ErrorMessage = "Host comments cannot exceed 500 characters.")]
        public string HostComments { get; set; }

        [Display(Name = "Dispute Status")]
        public DisputeStatus? DisputeStatus { get; set; }

        // FK relationships
        public AppUser User { get; set; }
        public Property Property { get; set; }
    }
}
