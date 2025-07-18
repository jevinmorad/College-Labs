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

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var appointment = _db.Users.Find(id);
            if (appointment != null)
            {
                _db.Users.Remove(appointment);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}