using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Category ID")]
        public Int32 CategoryID { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
        public string CategoryName { get; set; }

        public List<Property> Properties { get; set; }

        public Category() 
        { 
            if (Properties == null) 
            {  
                Properties = new List<Property>(); 
            }
        }
    }
}
