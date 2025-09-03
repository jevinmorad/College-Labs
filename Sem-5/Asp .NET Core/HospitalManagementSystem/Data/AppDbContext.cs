using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data
{ 
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorDepartment> DoctorDepartments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DoctorDepartment>()
                .HasOne(d => d.Doctor)
                .WithMany(dd => dd.DoctorDepartments)
                .HasForeignKey(d => d.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DoctorDepartment>()
                .HasOne(dd => dd.User)
                .WithMany()
                .HasForeignKey(dd => dd.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}