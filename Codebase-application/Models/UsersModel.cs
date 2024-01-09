using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Codebase_application.Models
{
    public class UsersModel
    {
        [Required(ErrorMessage = "Please enter First Name")]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} characters", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters, " +
            "at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number, and 1 Special Character")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email Id")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Entered mobile number format is not valid.")]
        public string MobileNo { get; set; }
    }
}