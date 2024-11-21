using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public enum HireStatus { Employed, Terminated }

    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address")]
        public string LineAddress1 { get; set; }

        [Required(ErrorMessage = "A postal code is required.")]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid postal code format. Use 12345 or 12345-6789.")]
        public string? PostalCode { get; set; }

        [Display(Name = "Hire Status")]
        public HireStatus? HireStatus { get; set; }


        // navigational properties for many relationships
        public List<Reservation> Reservations { get; set; }
        public List<Property> Properties { get; set; }
        public List<Review> Reviews { get; set; }


        // constructor to prevent any null references 
        public AppUser()
        {
            if (Reservations == null)
            { 
                Reservations = new List<Reservation>(); 
            }

            if (Properties == null) 
            { 
                Properties = new List<Property>(); 
            }

            if (Reviews == null) 
            { 
                Reviews = new List<Review>(); 
            }
        }

        
        // read only properties below (these will not be in the db schema)
    }
}
