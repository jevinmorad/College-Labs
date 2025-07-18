using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        #region Configuration
        private readonly AppDbContext _db;
        public PatientController(AppDbContext db)
        {
            _db = db;
        }
        #endregion

        #region List
        public IActionResult List()
        {
            List<Patient> patients = _db.Patients.ToList();
            return View(patients);
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var patient = _db.Users.Find(id);
            if (patient != null)
            {
                _db.Users.Remove(patient);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}