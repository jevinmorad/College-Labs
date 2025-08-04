using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required(ErrorMessage = "Doctor is required"), ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        [Required(ErrorMessage = "Patient is required"), ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "Appointment date is required") ,DisplayName("Appoint Date & Time")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Appointment status is required"), StringLength(20), DisplayName("Status")]
        public string AppointmentStatus { get; set; }

        [Required(ErrorMessage = "Appointment description is required"), StringLength(250), DisplayName("Description")]
        public string Description { get; set; }

        [StringLength(100), DisplayName("Special Remarks")]
        public string SpecialRemarks { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        [Required, ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        [Column(TypeName = "decimal(10,2)"), DisplayName("Total Consulted Amount")]
        public decimal? TotalConsultedAmount { get; set; }
    }
}