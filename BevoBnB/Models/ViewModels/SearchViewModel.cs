using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public class ProfileSearchViewModel
    {
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
    }
}
