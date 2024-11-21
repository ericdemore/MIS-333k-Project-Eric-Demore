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
        public string CategoryName { get; set; }

        
        // navigational properties for the foreign key relationships
        public List<Property> Properties { get; set; }


        // constructor to prevent any null references 
        public Category() 
        { 
            if (Properties == null) 
            {  
                Properties = new List<Property>(); 
            }
        }
    }
}
