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

        [Required, ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        [Required, ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        [Required ,DisplayName("Appoint Date & Time")]
        public DateTime AppointmentDate { get; set; }

        [Required, StringLength(20), DisplayName("Status")]
        public string AppointmentStatus { get; set; }

        [Required, StringLength(250), DisplayName("Description")]
        public string Description { get; set; }

        [Required, StringLength(100), DisplayName("Special Remarks")]
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