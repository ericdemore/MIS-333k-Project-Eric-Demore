﻿using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public class Category
    {
        [Key]
        public Int32 CategoryID { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [Display(Name = "Category")]
        [StringLength(100, ErrorMessage = "Category name can't be longer than 100 characters")]
        public String CategoryName { get; set; }
    }
}
