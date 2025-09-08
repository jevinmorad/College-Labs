using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HospitalManagementSystem.Controllers
{
    [CheckAccess]
    public class DepartmentController : Controller
    {
        #region Configuration
        private readonly AppDbContext _db;
        public DepartmentController(AppDbContext db)
        {
            _db = db;
        }
        #endregion

        #region List
        public IActionResult List()
        {

            List<Department> departments = _db.Departments.ToList();
            if (departments == null)
            {
                return View("NoDataFound");
            }
            return View(departments);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            _db.Departments.Add(department);
            _db.SaveChanges();

            TempData["success"] = $"Department '{department.DepartmentName} created'";
            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                TempData["error"] = "Department Id not found";
                return NotFound();
            }
            var decryptedId = Convert.ToInt32(UrlEncryptor.Decrypt(id));

            var department = _db.Departments.Find(decryptedId);
            if (department == null)
            {
                TempData["error"] = $"Department not found";
                return NotFound();
            }

            return View("Create", department);
        }
        [HttpPost]
        public IActionResult Edit(Department obj)
        {
            if (obj.DepartmentID == 0)
            {
                TempData["error"] = $"Department not found";
                return NotFound();
            }

            var department = _db.Departments.Find(obj.DepartmentID);
            if (department == null)
            {
                TempData["error"] = $"Department not found";
                return NotFound();
            }
            
            if (!ModelState.IsValid)
            {
                return View("Create", obj);
            }

            department.DepartmentName = obj.DepartmentName;
            department.Description = obj.Description;
            department.IsActive = obj.IsActive;

            _db.SaveChanges();

            TempData["success"] = $"Department '{department.DepartmentName} edited'";
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var department = _db.Departments.Find(id);

            if (department == null)
            {
                TempData["error"] = "Department not found";
                return RedirectToAction("List");
            }
            department.IsActive = false;
            department.Modified = DateTime.Now;
            _db.SaveChanges();

            TempData["success"] = $"Department '{department.DepartmentName}' has been successfully deactivated.";

            return RedirectToAction("List");
        }
        #endregion
    }
}