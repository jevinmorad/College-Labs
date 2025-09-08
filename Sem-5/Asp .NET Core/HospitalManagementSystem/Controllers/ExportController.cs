using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.Text;

namespace HospitalManagementSystem.Controllers
{
    public class ExportController : Controller
    {
        private readonly AppDbContext _db;

        public ExportController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExportToCsv(List<string> selectedModels)
        {
            if (selectedModels == null || !selectedModels.Any())
            {
                TempData["error"] = "Please select at least one data type to export.";
                return Redirect(Request.Headers["Referer"].ToString());
            }

            using var zipStream = new MemoryStream();
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                foreach (var model in selectedModels)
                {
                    string csvContent = "";
                    string fileName = "";

                    switch (model)
                    {
                        case "Patients":
                            var patients = await _db.Patients.ToListAsync();
                            var sbPatients = new StringBuilder();
                            sbPatients.AppendLine("PatientID,Name,Email,Phone,DateOfBirth,Gender,Address,City,State,IsActive");
                            foreach (var p in patients)
                            {
                                sbPatients.AppendLine($"\"{p.PatientID}\",\"{p.Name}\",\"{p.Email}\",\"{p.Phone}\",\"{p.DateOfBirth:yyyy-MM-dd}\",\"{p.Gender}\",\"{p.Address}\",\"{p.City}\",\"{p.State}\",\"{p.IsActive}\"");
                            }
                            csvContent = sbPatients.ToString();
                            fileName = "Patients.csv";
                            break;

                        case "Doctors":
                            var doctors = await _db.Doctors.ToListAsync();
                            var sbDoctors = new StringBuilder();
                            sbDoctors.AppendLine("DoctorId,Name,Email,Phone,Qualification,Specialization,IsActive");
                            foreach (var d in doctors)
                            {
                                sbDoctors.AppendLine($"\"{d.DoctorId}\",\"{d.Name}\",\"{d.Email}\",\"{d.Phone}\",\"{d.Qualification}\",\"{d.Specialization}\",\"{d.IsActive}\"");
                            }
                            csvContent = sbDoctors.ToString();
                            fileName = "Doctors.csv";
                            break;

                        case "Departments":
                            var departments = await _db.Departments.ToListAsync();
                            var sbDepartments = new StringBuilder();
                            sbDepartments.AppendLine("DepartmentID,DepartmentName,Description,IsActive");
                            foreach (var dep in departments)
                            {
                                sbDepartments.AppendLine($"\"{dep.DepartmentID}\",\"{dep.DepartmentName}\",\"{dep.Description}\",\"{dep.IsActive}\"");
                            }
                            csvContent = sbDepartments.ToString();
                            fileName = "Departments.csv";
                            break;

                        case "Appointments":
                            var appointments = await _db.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();
                            var sbAppointments = new StringBuilder();
                            sbAppointments.AppendLine("AppointmentID,PatientName,DoctorName,AppointmentDate,Status,Description,Fee");
                            foreach (var a in appointments)
                            {
                                sbAppointments.AppendLine($"\"{a.AppointmentID}\",\"{a.Patient?.Name}\",\"{a.Doctor?.Name}\",\"{a.AppointmentDate:yyyy-MM-dd HH:mm}\",\"{a.AppointmentStatus}\",\"{a.Description}\",\"{a.TotalConsultedAmount}\"");
                            }
                            csvContent = sbAppointments.ToString();
                            fileName = "Appointments.csv";
                            break;
                    }

                    if (!string.IsNullOrEmpty(csvContent))
                    {
                        var entry = archive.CreateEntry(fileName);
                        using var entryStream = entry.Open();
                        using var writer = new StreamWriter(entryStream, Encoding.UTF8);
                        writer.Write(csvContent);
                    }
                }
            }

            zipStream.Position = 0;
            string zipFileName = $"HMS_Export_{DateTime.Now:yyyyMMdd_HHmm}.zip";
            return File(zipStream.ToArray(), "application/zip", zipFileName);
        }
    }
}