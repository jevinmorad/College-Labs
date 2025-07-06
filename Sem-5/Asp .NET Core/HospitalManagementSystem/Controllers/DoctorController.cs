using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View("DoctorList");
        }
    }
}
