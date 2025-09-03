using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System.Reflection;

namespace HospitalManagementSystem.Controllers
{
    [CheckAccess]
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
            if (users == null)
            {
                return View("NoDataFound");
            }
            return View(users);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User obj, IFormFile ProfilePhoto)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", obj);
            }
            if(ProfilePhoto !=null && ProfilePhoto.Length > 0)
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

                obj.ProfilePhoto = "/images/" + fileName;
            } 
            else
            {
                obj.ProfilePhoto = "/images/default-profile.png";
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
        public IActionResult Edit(User obj, IFormFile ProfilePhoto)
        {
            if (obj.UserID == 0)
                return NotFound();

            ModelState.Remove("ProfilePhoto");
            if (!ModelState.IsValid)
            {
                return View("Create", obj);
            }

            var user = _db.Users.Find(obj.UserID);

            if (user == null)
                return NotFound();

            user.UserName = obj.UserName;
            user.Email = obj.Email;
            user.MobileNo = obj.MobileNo;
            user.IsActive = obj.IsActive;
            user.Modified = DateTime.Now;

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

                user.ProfilePhoto = "/images/" + fileName;
            }

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