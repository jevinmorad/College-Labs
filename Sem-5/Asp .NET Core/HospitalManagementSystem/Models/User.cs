using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name is required"), StringLength(100, MinimumLength = 3), DisplayName("Full Name")]
        public string UserName { get; set; }

        [DisplayName("Profile photo")]
        [DefaultValue("/images/default-profile.png")]
        [ValidateNever]
        public string? ProfilePhoto { get; set; } 

        [Required, StringLength(100, MinimumLength = 6, ErrorMessage = "Enter atleast 6 characters"), DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required"), StringLength(100), DisplayName("Email"), EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is require"), StringLength(100), DisplayName("Mobile No"), Phone(ErrorMessage = "Invalid mobile number")]
        public string MobileNo { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}