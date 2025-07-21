using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required, StringLength(100), DisplayName("Full Name")]
        public string Name { get; set; }

        [Required, DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required, StringLength(10), DisplayName("Gender")]
        public string Gender { get; set; }

        [Required, StringLength(100), DisplayName("Email")]
        public string Email { get; set; }

        [Required, StringLength(100), DisplayName("Mobile no")]
        public string Phone { get; set; }

        [Required, StringLength(250), DisplayName("Address")]
        public string Address { get; set; }

        [Required, StringLength(100), DisplayName("City")]
        public string City { get; set; }

        [Required, StringLength(100), DisplayName("State")]
        public string State { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        [Required, ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}