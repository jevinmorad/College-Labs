using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System.Linq;

namespace HospitalManagementSystem.Controllers
{
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
            List<Appointment> appointments = _db.Appointments.ToList();
            return View(appointments);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var appointment = _db.Appointments.Find(id);
            if (appointment == null)
                return NotFound();

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

            appointment.DoctorID = obj.DoctorID;
            appointment.PatientID = obj.PatientID;
            appointment.AppointmentDate = obj.AppointmentDate;
            appointment.AppointmentStatus = obj.AppointmentStatus;
            appointment.Description = obj.Description;
            appointment.SpecialRemarks = obj.SpecialRemarks;
            appointment.TotalConsultedAmount = obj.TotalConsultedAmount;

            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var appointment = _db.Appointments.Find(id);
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