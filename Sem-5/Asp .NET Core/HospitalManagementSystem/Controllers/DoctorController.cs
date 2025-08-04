using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        #region Configuration
        private readonly AppDbContext _db;
        public DoctorController(AppDbContext db)
        {
            _db = db;
        }
        #endregion

        #region List
        public IActionResult List()
        {
            List<Doctor> doctors = _db.Doctors.ToList();
            return View(doctors);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }
            _db.Doctors.Add(doctor);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var doctor = _db.Doctors.Find(id);
            if (doctor == null)
                return NotFound();

            return View("Create", doctor);
        }
        [HttpPost]
        public IActionResult Edit(Doctor obj)
        {
            if (obj.DoctorId == 0)
                return NotFound();
            
            var doctor = _db.Doctors.Find(obj.DoctorId);
            if(doctor == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View("Create", obj);
            }

            doctor.Name = obj.Name;
            doctor.Email = obj.Email;
            doctor.Phone = obj.Phone;
            doctor.Qualification = obj.Qualification;
            doctor.Specialization = obj.Specialization;
            doctor.Modified = obj.Modified;

            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var doctor = _db.Doctors.Find(id);
            if (doctor != null)
            {
                _db.Doctors.Remove(doctor);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}
