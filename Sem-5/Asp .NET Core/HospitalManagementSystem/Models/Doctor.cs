using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Name is required"), StringLength(100), DisplayName("Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile number is required"), StringLength(20), DisplayName("Mobile No")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required"), StringLength(100), DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Qualification is required"), StringLength(100), DisplayName("Qualifiaction")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Specialization is required"), StringLength(100), DisplayName("Specialization")]
        public string Specialization { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        [Required, ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
