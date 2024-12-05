using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public class PropertyDetailsViewModel
    {
        public int PropertyID { get; set; }
        public int PropertyNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }

    public class ReviewViewModel
    {
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
    }

    public class AddUnavailableDateViewModel
    {
        [Required]
        public int PropertyID { get; set; }

        [Required(ErrorMessage = "Please provide a valid date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Unavailable Date")]
        public DateTime UnavailableDate { get; set; }
    }
}
