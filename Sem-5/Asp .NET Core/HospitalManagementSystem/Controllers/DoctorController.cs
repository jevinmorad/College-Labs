using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text.Encodings.Web;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace HospitalManagementSystem.Controllers
{
    [CheckAccess]
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
            var doctors = _db.Doctors
                .Include(d => d.DoctorDepartments)
                .ThenInclude(dd => dd.Department)
                .ToList();
            return View(doctors);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_db.Departments, "DepartmentID", "DepartmentName");
            return View(new Doctor());
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor, IFormFile ProfilePhoto, int SelectedDepartmentId)
        {
            ModelState.Remove("ProfilePhoto");
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(_db.Departments, "DepartmentID", "DepartmentName");
                return View("Create", doctor);
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

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ProfilePhoto.CopyTo(stream);
                }
                doctor.ProfilePhoto = "/images/" + fileName;
            }
            else
            {
                doctor.ProfilePhoto = "/images/default-profile.png";
            }

            _db.Doctors.Add(doctor);
            _db.SaveChanges();

            var doctorDepartment = new DoctorDepartment
            {
                DoctorID = doctor.DoctorId,
                DepartmentID = SelectedDepartmentId,
                UserID = doctor.UserID,
                Created = DateTime.Now,
                Modified = DateTime.Now
            };

            _db.DoctorDepartments.Add(doctorDepartment);
            _db.SaveChanges();

            TempData["success"] = $"Doctor '{doctor.Name}' was created successfully.";

            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                TempData["error"] = "Doctor Id not found";
                return NotFound();
            }

            int decryptedId = Convert.ToInt32(UrlEncryptor.Decrypt(id));
            var doctor = _db.Doctors.Find(decryptedId);
            
            var selectedDepartmentId = _db.DoctorDepartments.FirstOrDefault(dd => dd.DoctorID == decryptedId)?.DepartmentID;

            ViewBag.Departments = new SelectList(_db.Departments, "DepartmentID", "DepartmentName", selectedDepartmentId);
            ViewBag.SelectedDepartmentId = selectedDepartmentId;

            return View("Create", doctor);
        }

        [HttpPost]
        public IActionResult Edit(Doctor doctor, IFormFile ProfilePhoto, int SelectedDepartmentId)
        {
            ModelState.Remove("ProfilePhoto");
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(_db.Departments, "DepartmentID", "DepartmentName");
                return View("Create", doctor);
            }

            var doctorToUpdate = _db.Doctors.Find(doctor.DoctorId);
            if (doctorToUpdate == null)
            {
                TempData["error"] = "Doctor not found";
                return NotFound();
            }

            doctorToUpdate.Name = doctor.Name;
            doctorToUpdate.Email = doctor.Email;
            doctorToUpdate.Phone = doctor.Phone;
            doctorToUpdate.Qualification = doctor.Qualification;
            doctorToUpdate.Specialization = doctor.Specialization;
            doctorToUpdate.IsActive = doctor.IsActive;
            doctorToUpdate.Modified = DateTime.Now;

            if (ProfilePhoto != null && ProfilePhoto.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePhoto.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ProfilePhoto.CopyTo(stream);
                }
                doctorToUpdate.ProfilePhoto = "/images/" + fileName;
            }

            var existingDoctorDepartment = _db.DoctorDepartments
                .FirstOrDefault(dd => dd.DoctorID == doctorToUpdate.DoctorId);

            if (existingDoctorDepartment != null)
            {
                existingDoctorDepartment.DepartmentID = SelectedDepartmentId;
                existingDoctorDepartment.Modified = DateTime.Now;
            }
            else
            {
                var newDoctorDepartment = new DoctorDepartment
                {
                    DoctorID = doctorToUpdate.DoctorId,
                    DepartmentID = SelectedDepartmentId,
                    UserID = 1,
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                };
                _db.DoctorDepartments.Add(newDoctorDepartment);
            }
            _db.SaveChanges();

            TempData["success"] = $"Doctor '{doctor.Name}' was updated successfully.";

            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var doctor = _db.Doctors.Find(id);

            if (doctor == null)
            {
                TempData["error"] = "Doctor not found.";
                return RedirectToAction("List");
            }

            doctor.IsActive = false;
            doctor.Modified = DateTime.Now;
            _db.Doctors.Update(doctor);
            _db.SaveChanges();

            TempData["success"] = $"Doctor '{doctor.Name}' has been successfully deactivated.";

            return RedirectToAction("List");
        }
        #endregion
    }
}