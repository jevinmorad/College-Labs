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
        public Doctor Doctor { get; set; }

        [Required, ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
            
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        [Required, ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}