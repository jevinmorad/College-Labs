using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult ListUsers()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }

        public IActionResult CreateEditUser()
        {
            return View();
        }

        public IActionResult CreateEditUser(int? id)
        {
            if (id == null || id == 0)
            {
                // Create new
                ViewBag.IsEdit = false;
                return View(new User());
            }
            else
            {
                // Edit existing
                var user = _db.Users.FirstOrDefault(u => u.UserID == id);
                if (user == null)
                {
                    return NotFound();
                }
                ViewBag.IsEdit = true;
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult CreateEditUser(User obj)
        {
            if (obj.UserID == 0)
            {
                // New user
                _db.Users.Add(obj);
            }
            else
            {
                // Existing user, update
                _db.Users.Update(obj);
            }

            _db.SaveChanges();
            return RedirectToAction("ListUsers");
        }


        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
            return RedirectToAction("ListUsers");
        }
    }
}