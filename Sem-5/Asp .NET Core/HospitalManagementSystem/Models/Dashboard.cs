namespace HospitalManagementSystem.Models
{
    public class Dashboard
    {
        public decimal TodaysRevenue { get; set; }
        public int ScheduledAppointmentsToday { get; set; }
        public int NewPatientsToday { get; set; }
        public int TotalBedsAvailable { get; set; }
        public List<Appointment> TodaysAppointments { get; set; }
        public Dictionary<string, int> DoctorAppointmentCounts { get; set; }
        public int CancelledAppointmentsToday { get; set; }

        public List<string> ChartLabels { get; set; }

        public List<decimal> RevenueData { get; set; }

        public List<string> DoctorPerformanceLabels { get; set; }
        public List<int> DoctorPerformanceData { get; set; }
        public int MalePatients { get; set; }
        public int FemalePatients { get; set; }
        public Dictionary<string, int> PatientCountByAgeGroup { get; set; }
        public int TotalAppointmentsInPeriod { get; internal set; }
        public int CompletedAppointmentsInPeriod { get; internal set; }
        public int ScheduledAppointmentsInPeriod { get; internal set; }
        public int CancelledAppointmentsInPeriod { get; internal set; }
    }
}
