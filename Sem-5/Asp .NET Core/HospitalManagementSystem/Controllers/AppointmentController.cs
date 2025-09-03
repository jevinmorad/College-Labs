using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult List()
        {
            List<Appointment> appointments = _db.Appointments
                                        .Include(a => a.Doctor)
                                        .Include(a => a.Patient)
                                        .ToList();
            return View(appointments);
        }
        public IActionResult Details(int id)
        {
            var appointment = _db.Appointments
                                 .Include(a => a.Doctor)
                                 .Include(a => a.Patient)
                                 .FirstOrDefault(a => a.AppointmentID == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return PartialView("_AppointmentDetails", appointment);
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
            if (!ModelState.IsValid)
            {
                PopulateDropdowns();
                return View(appointment);
            }
            appointment.Doctor = _db.Doctors.Find(appointment.DoctorID);
            appointment.Patient = _db.Patients.Find(appointment.PatientID);
            appointment.User = _db.Users.Find(appointment.UserID);
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(string? id)
        {
            if (id == null)
                return NotFound();

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
                return NotFound();

            var appointment = _db.Appointments.Find(obj.AppointmentID);
            if (appointment == null)
                return NotFound();

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
            appointment.Doctor = _db.Doctors.Find(appointment.DoctorID);
            appointment.Patient = _db.Patients.Find(appointment.PatientID);

            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(string id)
        {
            var decryptedId = Convert.ToInt32(UrlEncryptor.Decrypt(WebUtility.UrlDecode(id)));

            var appointment = _db.Appointments.Find(decryptedId);
            if (appointment != null)
            {
                _db.Appointments.Remove(appointment);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}