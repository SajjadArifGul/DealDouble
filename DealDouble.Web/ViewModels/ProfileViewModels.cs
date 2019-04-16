using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class ProfileDetailsViewModel : PageViewModel
    {
        public DealDoubleUser User { get; set; }
    }

    public class UpdateProfileDetailsViewModel : PageViewModel
    {
        [MaxLength(20, ErrorMessage = "The FullName must be at most 20 characters long.")]
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
       
    }

    public class UpdatePasswordViewModel : PageViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}