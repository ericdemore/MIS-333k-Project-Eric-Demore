using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BevoBnB.ViewModels
{
    public class ReviewCreateViewModel
    {
        [Required]
        [Display(Name = "Property")]
        public int PropertyID { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Display(Name = "Comment (Optional)")]
        public string? ReviewText { get; set; }

        public List<SelectListItem> PropertyOptions { get; set; }
    }
}
