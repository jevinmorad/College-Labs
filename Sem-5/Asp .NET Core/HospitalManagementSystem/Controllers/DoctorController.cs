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

            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(string? id)
        {
            if (id == null) return NotFound();

            int decryptedId = Convert.ToInt32(UrlEncryptor.Decrypt(id));
            var doctor = _db.Doctors.Find(decryptedId);
            if (doctor == null) return NotFound();
            
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
            if(doctorToUpdate == null) return NotFound();

            doctorToUpdate.Name = doctor.Name;
            doctorToUpdate.Email = doctor.Email;
            doctorToUpdate.Phone = doctor.Phone;
            doctorToUpdate.Qualification = doctor.Qualification;
            doctorToUpdate.Specialization = doctor.Specialization;
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
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(string id)
        {

            var decryptedId = Convert.ToInt32(UrlEncryptor.Decrypt(id));
            var doctor = _db.Doctors
                .Include(d => d.DoctorDepartments)
                .FirstOrDefault(d => d.DoctorId == decryptedId);

            if (doctor != null)
            {
                if (!string.IsNullOrEmpty(doctor.ProfilePhoto) && doctor.ProfilePhoto != "/images/default-profile.png") 
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", doctor.ProfilePhoto.TrimStart('/')); 
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath); 
                    }
                }

                if (doctor.DoctorDepartments.Any())
                {
                    _db.DoctorDepartments.RemoveRange(doctor.DoctorDepartments);
                }

                 _db.Doctors.Remove(doctor); 
        
                _db.SaveChanges(); 
            }
            return RedirectToAction("List"); 
        }
        #endregion
    }
}