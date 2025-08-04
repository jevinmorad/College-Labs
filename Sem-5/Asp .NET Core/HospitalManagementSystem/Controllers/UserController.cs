using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class UserController : Controller
    {
        #region Configuration
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }
        #endregion

        #region List
        public IActionResult List()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User obj)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", obj);
            }
            _db.Users.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var user = _db.Users.Find(id);
            if (user == null)
                return NotFound();

            return View("Create", user);
        }

        [HttpPost]
        public IActionResult Edit(User obj)
        {
            if (obj.UserID == 0)
                return NotFound();

            var user = _db.Users.Find(obj.UserID);
            if (user == null)
                return NotFound();

            if(!ModelState.IsValid)
            {
                return View("Create", obj);
            }

            user.UserName = obj.UserName;
            user.Email = obj.Email;
            user.MobileNo = obj.MobileNo;
            user.IsActive = obj.IsActive;
            user.Modified = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        #endregion
    }
}