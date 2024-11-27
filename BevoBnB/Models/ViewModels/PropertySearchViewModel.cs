using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.ViewModels
{
    public class PropertySearchViewModel
    {
        public string? City { get; set; } 

        public string? State { get; set; } 

        [Range(1, int.MaxValue, ErrorMessage = "Minimum Bedrooms must be at least 1.")]
        public int? Bedrooms { get; set; } 

        [Range(1, int.MaxValue, ErrorMessage = "Minimum Bathrooms must be at least 1.")]
        public int? Bathrooms { get; set; } 

        [Range(1, int.MaxValue, ErrorMessage = "Guests Allowed must be at least 1.")]
        public int? GuestsAllowed { get; set; } 

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal? MinPrice { get; set; } 

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal? MaxPrice { get; set; } 

        public bool PetsAllowed { get; set; } = false; // Default to false
        public bool FreeParking { get; set; } = false; // Default to false

        public int? CategoryId { get; set; } 

        public List<SelectListItem> Categories { get; set; } 

        public List<SelectListItem> States { get; set; } 

        [DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; } 

        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; } 
    }
}
