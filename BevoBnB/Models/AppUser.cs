using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BevoBnB.Models
{
    public enum States
    {
        AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA,
        HI, ID, IL, IN, IA, KS, KY, LA, ME, MD,
        MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ,
        NM, NY, NC, ND, OH, OK, OR, PA, RI, SC,
        SD, TN, TX, UT, VT, VA, WA, WV, WI, WY,
        OT
    }

    public enum HireStatus { Employed, Terminated }

    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name:")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Line address 1 is required.")]
        [Display(Name = "Line Address 1")]
        [StringLength(100, ErrorMessage = "Street address cannot exceed 100 characters.")]
        public String LineAddress1 { get; set; }

        [Display(Name = "Line address 2")]
        [StringLength(100, ErrorMessage = "Street address cannot exceed 100 characters.")]
        public String? LineAddress2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        public String City { get; set; }

        [Required(ErrorMessage = "A state is required.")]
        [Display(Name = "State")]
        public States State { get; set; }

        [Required(ErrorMessage = "A postal code is required.")]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid postal code format. Use 12345 or 12345-6789.")]
        public String PostalCode { get; set; }

        public HireStatus? HireStatus { get; set; }

        public bool IsMinimumAge(DateTime DOB)
        {
            Int32 requiredAge = 21;

            Int32 currentAge = DateTime.Today.Year - DOB.Year;

            // if the birthday has not occurred yet this year, subtract one year from the age
            if (DOB.Date > DateTime.Today.AddYears(-currentAge))
            {
                currentAge = currentAge - 1;
            }

            // returns true if condition is met; returns false is condition is not met
            return currentAge >= requiredAge;
        }
    }
}
