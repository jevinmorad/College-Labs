using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public String LastName { get; set; }

        [DisplayName("Profile photo")]
        [DefaultValue("/images/default-profile.png")]
        [ValidateNever]
        public string? ProfilePhoto { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public String PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "Hire date is required")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Job title is required")]
        public String JobTitle { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public String Department { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
