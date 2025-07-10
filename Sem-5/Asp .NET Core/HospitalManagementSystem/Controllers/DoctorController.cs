using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        private IConfiguration _configuration;
        public DoctorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            string? connectionString = _configuration.GetConnectionString("DBConnectionString");
            if (connectionString == null)
            {
                return BadRequest("Database connection string is not configured.");
            }
            return View("DoctorList");
        }
    }
}
