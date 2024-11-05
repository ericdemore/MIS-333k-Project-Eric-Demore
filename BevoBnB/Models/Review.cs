using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BevoBnB.Models
{
    public class Review
    {
        [Key]
        // primary key
        public int ReviewID { get; set; }

        [ForeignKey("AppUser")]
        public string UserID { get; set; }

        [ForeignKey("Property")]
        public int PropertyID { get; set; }

        [Range(1, 5)]
        // rating scale 1-5
        public int Rating { get; set; }

        [MaxLength(280)]
        // optional review up to 280 characters
        public string ReviewText { get; set; }

        // host comments on the review
        public string HostComments { get; set; }

        [EnumDataType(typeof(DisputeStatus))]
        // status of review dispute
        public DisputeStatus DisputeStatus { get; set; }

        // Navigation properties for relationships
        public virtual AppUser AppUser { get; set; }
        public virtual Property Property { get; set; }
    }

    // Define the DisputeStatus enum here
    public enum DisputeStatus
    {
        None,
        Disputed,
        Resolved
    }
}
