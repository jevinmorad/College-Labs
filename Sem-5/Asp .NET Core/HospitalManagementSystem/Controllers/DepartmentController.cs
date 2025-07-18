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

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var department = _db.Users.Find(id);
            if (department != null)
            {
                _db.Users.Remove(department);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}