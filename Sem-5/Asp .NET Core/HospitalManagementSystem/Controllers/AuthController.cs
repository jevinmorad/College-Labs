using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        #region Configuration
        private readonly AppDbContext _db;
        public AuthController(AppDbContext db)
        {
            _db = db;
        }
        #endregion

        public IActionResult Login()
        {
            UserAuth userLogin = new UserAuth();
            return View(userLogin);
        }
        [HttpPost]
        public IActionResult Login(UserAuth user)
        {
            var userData = _db.Users
                .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (userData == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(user);
            }
            HttpContext.Session.SetInt32("UserID", userData.UserID);
            HttpContext.Session.SetString("FirstName", userData.UserName);
            HttpContext.Session.SetString("Email", userData.Email);
            HttpContext.Session.SetString("ProfilePhoto", userData.ProfilePhoto ?? "/images/default-profile.png");
            HttpContext.Session.SetString("MobileNo", userData.MobileNo);
            return RedirectToAction("Index", "Dashboard");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User obj, IFormFile ProfilePhoto)
        {
            ModelState.Remove("ProfilePhoto");
            if (!ModelState.IsValid)
            {
                return View("Register", obj);
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

                obj.ProfilePhoto = "/images/" + fileName;
            }
            else
            {
                obj.ProfilePhoto = "/images/default-profile.png";
            }
            _db.Users.Add(obj);
            _db.SaveChanges();

            HttpContext.Session.SetInt32("UserID", obj.UserID);
            HttpContext.Session.SetString("FirstName", obj.UserName);
            HttpContext.Session.SetString("Email", obj.Email);
            HttpContext.Session.SetString("ProfilePhoto", obj.ProfilePhoto ?? "/images/default-profile.png");
            HttpContext.Session.SetString("MobileNo", obj.MobileNo);
            return RedirectToAction("Index", "Dashboard");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
