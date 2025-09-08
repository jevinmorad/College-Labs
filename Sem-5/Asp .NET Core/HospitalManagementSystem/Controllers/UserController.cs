using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
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

        public IActionResult Profile()
        {
            var userId = CommonVariable.UserID();
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth"); // Or handle as needed
            }
            return RedirectToAction("Details", new { id = UrlEncryptor.Encrypt(userId.ToString()) });
        }

        // Displays the user's profile in a read-only view
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();
            int decryptedId = Convert.ToInt32(UrlEncryptor.Decrypt(id));
            var user = await _db.Users.FindAsync(decryptedId);
            if (user == null) return NotFound();
            return View(user);
        }

        // GET: Displays the form for creating a new user
        public IActionResult Create()
        {
            return View(new User());
        }

        // POST: Handles the creation of a new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user, IFormFile ProfilePhotoFile)
        {
            ModelState.Remove("ProfilePhoto"); // Remove to allow manual handling
            if (ModelState.IsValid)
            {
                if (ProfilePhotoFile != null && ProfilePhotoFile.Length > 0)
                {
                    // Logic to save the new profile photo
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePhotoFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ProfilePhotoFile.CopyToAsync(stream);
                    }
                    user.ProfilePhoto = "/images/" + fileName;
                }

                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
                TempData["success"] = "User created successfully.";
                return RedirectToAction("List"); // Assuming you have a List view
            }
            return View(user);

        }

        // GET: Displays the form for editing an existing user
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();
            int decryptedId = Convert.ToInt32(UrlEncryptor.Decrypt(id));
            var user = await _db.Users.FindAsync(decryptedId);
            if (user == null) return NotFound();
            return View("Create", user); // Re-uses the Create view for editing
        }

        // POST: Handles the update of an existing user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user, IFormFile ProfilePhotoFile)
        {
            ModelState.Remove("ProfilePhoto");
            ModelState.Remove("Password"); // Password is not updated here
            if (ModelState.IsValid)
            {
                var userToUpdate = await _db.Users.FindAsync(user.UserID);
                if (userToUpdate == null) return NotFound();

                userToUpdate.UserName = user.UserName;
                userToUpdate.Email = user.Email;
                userToUpdate.MobileNo = user.MobileNo;
                userToUpdate.Modified = DateTime.Now;

                if (ProfilePhotoFile != null && ProfilePhotoFile.Length > 0)
                {
                    // Logic to save a new profile photo and update the path
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePhotoFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ProfilePhotoFile.CopyToAsync(stream);
                    }
                    userToUpdate.ProfilePhoto = "/images/" + fileName;
                }

                _db.Users.Update(userToUpdate);
                await _db.SaveChangesAsync();
                TempData["success"] = "Profile updated successfully.";
                return RedirectToAction("Details", new { id = UrlEncryptor.Encrypt(user.UserID.ToString()) });
            }
            return View("Create", user);
        }
    }
}