using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System.Linq;

namespace HospitalManagementSystem.Controllers
{
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
            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var department = _db.Departments.Find(id);
            if (department == null)
                return NotFound();

            return View("Create", department);
        }
        [HttpPost]
        public IActionResult Edit(Department obj)
        {
            if (obj.DepartmentID == 0)
                return NotFound();

            var department = _db.Departments.Find(obj.DepartmentID);
            if (department == null)
                return NotFound();
            
            if (!ModelState.IsValid)
            {
                return View("Create", obj);
            }

            department.DepartmentName = obj.DepartmentName;
            department.Description = obj.Description;
            department.IsActive = obj.IsActive;

            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var department = _db.Departments.Find(id);
            if (department != null)
            {
                _db.Departments.Remove(department);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}