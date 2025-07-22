using Microsoft.AspNetCore.Http.HttpResults;

namespace HospitalManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Gender { get; set; }
        public DateTime HireDate { get; set; }
        public String JobTitle { get; set; }
        public String Department { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
