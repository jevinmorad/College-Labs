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

        [Required(ErrorMessage = "Name is required"), StringLength(100), DisplayName("Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Birthdate is required"), DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required"), StringLength(10), DisplayName("Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required"), StringLength(100), DisplayName("Email"), EmailAddress(ErrorMessage = "Invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required"), StringLength(100), DisplayName("Mobile no"), Phone(ErrorMessage = "Invalid mobile number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required"), StringLength(250), DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required"), StringLength(100), DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required"), StringLength(100), DisplayName("State")]
        public string State { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "UserId is reuiqred"), ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}