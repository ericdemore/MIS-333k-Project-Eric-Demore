using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public enum CustomerState
    {
        Alabama, Alaska, Arizona, Arkansas, California, Colorado, Connecticut, Delaware, Florida, Georgia,
        Hawaii, Idaho, Illinois, Indiana, Iowa, Kansas, Kentucky, Louisiana, Maine, Maryland, Massachusetts,
        Michigan, Minnesota, Mississippi, Missouri, Montana, Nebraska, Nevada, NewHampshire, NewJersey,
        NewMexico, NewYork, NorthCarolina, NorthDakota, Ohio, Oklahoma, Oregon, Pennsylvania, RhodeIsland,
        SouthCarolina, SouthDakota, Tennessee, Texas, Utah, Vermont, Virginia, Washington, WestVirginia,
        Wisconsin, Wyoming, Other
    }

    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "A first name is required.")]
        [Display(Name = "First Name:")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial:")]
        [StringLength(1, ErrorMessage = "Middle initial must be a single character.")]
        public String? MiddleInitial { get; set; }

        [Required(ErrorMessage = "A last name is required.")]
        [Display(Name = "Last Name:")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "A date of birth is required.")]
        [Display(Name = "Date of Birth:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Display(Name = "Street Address:")]
        [StringLength(100, ErrorMessage = "Street address cannot exceed 100 characters.")]
        public String StreetAddress { get; set; }

        [Required(ErrorMessage = "A city is required.")]
        [Display(Name = "City:")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        public String City { get; set; }

        [Required(ErrorMessage = "A state is required.")]
        [Display(Name = "State:")]
        public CustomerState State { get; set; }

        [Required(ErrorMessage = "A postal code is required.")]
        [Display(Name = "Postal Code:")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid postal code format. Use 12345 or 12345-6789.")]
        public String PostalCode { get; set; }


    }
}
