using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department name is required"), StringLength(100), DisplayName("Name")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Description is required"), StringLength(250), DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;

        [ValidateNever]
        public virtual ICollection<DoctorDepartment> DoctorDepartments { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;

        [Required, ForeignKey("User")]
        public int UserID { get; set; }
        [ValidateNever]
        public User User { get; set; }
    }
}