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

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            _db.Patients.Add(patient);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var patient = _db.Patients.Find(id);
            if (patient == null)
                return NotFound();

            return View("Create", patient);
        }
        [HttpPost]
        public IActionResult Edit(Patient obj)
        {
            if (obj.PatientID == 0)
                return NotFound();

            var patient = _db.Patients.Find(obj.PatientID);
            if (patient == null)
                return NotFound();

            patient.Name = obj.Name;
            patient.Email = obj.Email;
            patient.Phone = obj.Phone;
            patient.DateOfBirth = obj.DateOfBirth;
            patient.Gender = obj.Gender;
            patient.Address = obj.Address;
            patient.City = obj.City;
            patient.State = obj.State;

            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var patient = _db.Patients.Find(id);
            if (patient != null)
            {
                _db.Patients.Remove(patient);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}