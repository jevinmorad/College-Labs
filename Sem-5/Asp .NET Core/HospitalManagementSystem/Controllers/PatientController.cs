using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HospitalManagementSystem.Controllers
{
    [CheckAccess]
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
            if (patients == null)
            {
                return View("NoDataFound");
            }
            return View(patients);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View(new Patient());
        }
        [HttpPost]
        public IActionResult Create(Patient patient, IFormFile ProfilePhoto)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", patient);
            }
            if (ProfilePhoto != null && ProfilePhoto.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePhoto.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                FileStream stream = new FileStream(filePath, FileMode.CreateNew);
                ProfilePhoto.CopyTo(stream);
                stream.Close();

                patient.ProfilePhoto = "/images/" + fileName;
            }
            else
            {
                patient.ProfilePhoto = "/images/default-profile.png";
            }
            _db.Patients.Add(patient);
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
            var patient = _db.Patients.Find(decryptedId);
            if (patient == null)
                return NotFound();

            return View("Create", patient);
        }
        [HttpPost]
        public IActionResult Edit(Patient obj, IFormFile ProfilePhoto)
        {
            if (obj.PatientID == 0)
                return NotFound();

            ModelState.Remove("ProfilePhoto");
            if (!ModelState.IsValid)
            {
                return View("Create", obj);
            }

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

            if (ProfilePhoto != null && ProfilePhoto.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePhoto.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                FileStream stream = new FileStream(filePath, FileMode.Create);
                ProfilePhoto.CopyTo(stream);
                stream.Close();

                patient.ProfilePhoto = "/images/" + fileName;
            }

            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(string id)
        {
            var decryptedId = Convert.ToInt32(UrlEncryptor.Decrypt(id));
            var patient = _db.Patients.Find(decryptedId);

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