using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;

namespace HospitalManagementSystem.Controllers
{
    [CheckAccess]
    public class AppointmentController : Controller
    {
        #region Configuration
        private readonly AppDbContext _db;
        public AppointmentController(AppDbContext db)
        {
            _db = db;
        }
        #endregion

        #region List
        public IActionResult List(string patientName, int? doctorId, DateTime? appointmentDate, string status)
        {
            var query = _db.Appointments
                           .Include(a => a.Patient)
                           .Include(a => a.Doctor)
                           .AsQueryable();

            if (!string.IsNullOrEmpty(patientName))
            {
                query = query.Where(a => a.Patient.Name.Contains(patientName));
            }

            if (doctorId.HasValue)
            {
                query = query.Where(a => a.DoctorID == doctorId.Value);
            }

            if (appointmentDate.HasValue)
            {
                query = query.Where(a => a.AppointmentDate.Date == appointmentDate.Value.Date);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(a => a.AppointmentStatus == status);
            }

            var appointments = query.OrderByDescending(a => a.AppointmentDate).ToList();

            ViewData["PatientNameFilter"] = patientName;
            ViewData["DoctorIdFilter"] = doctorId;
            ViewData["AppointmentDateFilter"] = appointmentDate?.ToString("yyyy-MM-dd");
            ViewData["StatusFilter"] = status;

            ViewBag.Doctors = new SelectList(_db.Doctors.Where(d => d.IsActive), "DoctorId", "Name", doctorId);

            return View(appointments);
        }
        #endregion

        #region Create
        private void PopulateDropdowns(int? selectedDoctorId = null, int? selectedPatientId = null)
        {
            ViewBag.Doctors = new SelectList(_db.Doctors, "DoctorId", "Name", selectedDoctorId);
            ViewBag.Patients = new SelectList(_db.Patients, "PatientID", "Name", selectedPatientId);
        }
        public IActionResult Create()
        {
            PopulateDropdowns();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            appointment.Doctor = _db.Doctors.Find(appointment.DoctorID);
            appointment.Patient = _db.Patients.Find(appointment.PatientID);
            appointment.User = _db.Users.Find(appointment.UserID);

            if (!ModelState.IsValid)
            {
                PopulateDropdowns();
                return View(appointment);
            }
            _db.Appointments.Add(appointment);
            _db.SaveChanges();

            TempData["success"] = "Appointment was created";
            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                TempData["error"] = "Appointment not found";
                return NotFound();
            }

            var decryptedId = Convert.ToInt32(UrlEncryptor.Decrypt(id));

            var appointment = _db.Appointments.Find(decryptedId);
            if (appointment == null)
                return NotFound();

            PopulateDropdowns(appointment.DoctorID, appointment.PatientID);

            return View("Create", appointment);
        }
        [HttpPost]
        public IActionResult Edit(Appointment obj)
        {
            if (obj.AppointmentID == 0)
            {
                TempData["error"] = "Appointment not found";
                return NotFound();
            }

            var appointment = _db.Appointments.Find(obj.AppointmentID);
            if (appointment == null)
            {
                TempData["error"] = "Appointment not found";
                return NotFound();
            }

            appointment.Doctor = _db.Doctors.Find(appointment.DoctorID);
            appointment.Patient = _db.Patients.Find(appointment.PatientID);

            if (!ModelState.IsValid)
            {
                PopulateDropdowns(obj.DoctorID, obj.PatientID);
                return View("Create", obj);
            }

            appointment.DoctorID = obj.DoctorID;
            appointment.PatientID = obj.PatientID;
            appointment.AppointmentDate = obj.AppointmentDate;
            appointment.AppointmentStatus = obj.AppointmentStatus;
            appointment.Description = obj.Description;
            appointment.SpecialRemarks = obj.SpecialRemarks;
            appointment.TotalConsultedAmount = obj.TotalConsultedAmount;

            TempData["success"] = "Appointment has been updated";

            _db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult UpdateStatus(int appointmentId, string newStatus, string returnUrl = "")
        {
            if (appointmentId == 0 || string.IsNullOrEmpty(newStatus))
            {
                TempData["error"] = "Invalid data provided for status update.";
                return RedirectToAction("List");
            }

            var appointment = _db.Appointments.Find(appointmentId);
            if (appointment == null)
            {
                TempData["error"] = "Appointment not found.";
                return NotFound();
            }
                
            appointment.AppointmentStatus = newStatus;
            appointment.Modified = DateTime.Now;
            _db.Appointments.Update(appointment);
            _db.SaveChanges();

            TempData["success"] = "Appointment status updated successfully!";

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var appointment = _db.Appointments.Find(id);
            if (appointment == null)
            {
                TempData["error"] = "Appointment not found";
                return RedirectToAction("List");
            }
            _db.Appointments.Remove(appointment);
            _db.SaveChanges();

            TempData["success"] = "Appointment deleted successfully";
            return RedirectToAction("List");
        }
        #endregion
    }
}