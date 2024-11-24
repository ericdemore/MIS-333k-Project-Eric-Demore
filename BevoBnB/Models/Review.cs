using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BevoBnB.Models
{
    public enum DisputeStatus { NoDispute, Disputed, ValidDispute, InvalidDispute }

    public class Review
    {
        [Key]
        [Display(Name = "Review ID")]
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [StringLength(280, ErrorMessage = "Review cannot exceed 180 characters.")]
        [Display(Name = "Review Text")]
        public string? ReviewText { get; set; }

        [Display(Name = "Host Comments")]
        public string? HostComments { get; set; }

        [Display(Name = "Dispute Status")]
        public DisputeStatus? DisputeStatus { get; set; }

        // FK relationships
        public AppUser User { get; set; }
        public Property Property { get; set; }
    }
}
