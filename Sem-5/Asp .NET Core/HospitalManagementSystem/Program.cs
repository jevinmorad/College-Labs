using HospitalManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register AppDbContext with DI using SQL Server and connection string from configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"))
);

// Add MVC controllers and views
builder.Services.AddControllersWithViews();

// Add other services as needed
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Usual middleware setup...
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}");

app.Run();
