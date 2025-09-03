using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class DoctorDepartment
    {
        [Key]
        public int DoctorDepartmentID { get; set; }

        [Required, ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        [ValidateNever]
        public Doctor Doctor { get; set; }

        [Required, ForeignKey("Department")]
        public int DepartmentID { get; set; }
        [ValidateNever]
        public Department Department { get; set; }
            
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        [Required, ForeignKey("User")]
        public int UserID { get; set; }
        [ValidateNever]
        public User User { get; set; }
    }
}