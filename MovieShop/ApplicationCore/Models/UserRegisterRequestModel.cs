using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class UserRegisterRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password should be minimu of 8 characters", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$",
            ErrorMessage = "Password should have minimun og 8 characters and should include one upper, lower, number and a special char")]
        public string Password { get; set; }

        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

         [DataType(DataType.Date)]
         public DateTime DateOfBirth { get; set; }

        }
    }
