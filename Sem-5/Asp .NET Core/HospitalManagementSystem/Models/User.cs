using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(100), DisplayName("Full Name")]
        public string UserName { get; set; }

        [Required, StringLength(100), DisplayName("Password")]
        public string Password { get; set; }

        [Required, StringLength(100), DisplayName("Email")]
        public string Email { get; set; }

        [Required, StringLength(100), DisplayName("Mobile No")]
        public string MobileNo { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;
    }
}