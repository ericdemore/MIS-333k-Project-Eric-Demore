using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public class Category
    {
        [Key]
        // primary key
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
        // name of the category (e.g., apartment, cabin, condo, etc.)
        public string CategoryName { get; set; }

        // Navigation property for related properties
        public virtual ICollection<Property> Properties { get; set; }
    }
}
