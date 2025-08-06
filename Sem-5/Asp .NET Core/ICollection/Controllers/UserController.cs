using ICollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System;

namespace ICollection.Controllers
{
    public class UserController : Controller
    {
        private static List<UserModel> users = new List<UserModel>();

        public IActionResult UserAddEdit()
        {
            ViewBag.Users = users;
            return View(new UserModel());
        }

        #region WithMode
        //[HttpPost]
        //public IActionResult UserAddEdit(UserModel user, IFormFile ImageFile)
        //{
        //    if (ImageFile != null && ImageFile.Length > 0)
        //    {
        //        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        //        if (!Directory.Exists(uploadsFolder))
        //            Directory.CreateDirectory(uploadsFolder);

        //        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
        //        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //        FileStream stream = new FileStream(filePath, FileMode.CreateNew);
        //        ImageFile.CopyTo(stream);
        //        stream.Close();

        //        user.Image = "/images/" + uniqueFileName;
        //    }
        //    users.Add(user);

        //    ViewBag.Users = users;
        //    ModelState.Clear();
        //    return View(new UserModel());
        //}
        #endregion

        #region WithIFormCollection
        [HttpPost]
        public IActionResult UserAddEdit(IFormCollection fc)
        {
            var user = new UserModel
            {
                UserName = fc["UserName"].ToString(),
                Email = fc["Email"].ToString(),
                Password = fc["Password"].ToString(),
                Age = int.TryParse(fc["Age"], out int age) ? age : 0,
                Gender = fc["Gender"].ToString(),
                Hobbies = fc["Hobbies"].ToString(),
                Phone = fc["Phone"].ToString()
            };
            var ImageFile = fc.Files.GetFile("Image");
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);
                
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                
                FileStream stream = new FileStream(filePath, FileMode.CreateNew);
                ImageFile.CopyTo(stream);
                stream.Close();
                
                user.Image = "/images/" + uniqueFileName;
            }

            users.Add(user);
            ViewBag.Users = users;
            ModelState.Clear();
            return View(new UserModel());
        }
        #endregion
    }
}