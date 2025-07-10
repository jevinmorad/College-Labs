using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data
{ 
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
