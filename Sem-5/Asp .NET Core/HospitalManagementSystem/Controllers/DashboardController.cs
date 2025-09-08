using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    [CheckAccess]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;

        public DashboardController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? year, int? month)
        {
            var today = DateTime.Today;
            int filterYear = year ?? today.Year;
            int? filterMonth = month;

            var todaysAppointments = _db.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.AppointmentDate.Date == today)
                .ToList();

            var allAppointmentsForPeriod = _db.Appointments
                .Where(a => a.AppointmentDate.Year == filterYear);

            if (filterMonth.HasValue)
            {
                allAppointmentsForPeriod = allAppointmentsForPeriod.Where(a => a.AppointmentDate.Month == filterMonth.Value);
            }
            var appointmentsInPeriod = allAppointmentsForPeriod.ToList();


            var viewModel = new Dashboard
            {
                DoctorAppointmentCounts = todaysAppointments
                .GroupBy(a => a.Doctor.Name)
                .ToDictionary(g => g.Key, g => g.Count())
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value),

                TodaysRevenue = todaysAppointments
                    .Where(a => a.AppointmentStatus.ToLower() == "completed")
                    .Sum(a => a.TotalConsultedAmount),
                ScheduledAppointmentsToday = todaysAppointments.Count(a => a.AppointmentStatus.ToLower() == "scheduled"),
                NewPatientsToday = _db.Patients.Count(p => p.Created.Date == today),
                CancelledAppointmentsToday = todaysAppointments.Count(a => a.AppointmentStatus.ToLower() == "cancelled"),

                TodaysAppointments = todaysAppointments
                    .OrderBy(a => a.AppointmentStatus.ToLower() != "scheduled")
                    .ThenBy(a => a.AppointmentDate)
                    .ToList(),

                TotalAppointmentsInPeriod = appointmentsInPeriod.Count(),
                CompletedAppointmentsInPeriod = appointmentsInPeriod.Count(a => a.AppointmentStatus.ToLower() == "completed"),
                ScheduledAppointmentsInPeriod = appointmentsInPeriod.Count(a => a.AppointmentStatus.ToLower() == "scheduled"),
                CancelledAppointmentsInPeriod = appointmentsInPeriod.Count(a => a.AppointmentStatus.ToLower() == "cancelled"),

                ChartLabels = new List<string>(),
                RevenueData = new List<decimal>()
            };

            var revenueQuery = _db.Appointments
                .Where(a => a.AppointmentStatus.ToLower() == "completed" && a.AppointmentDate.Year == filterYear);

            if (filterMonth.HasValue)
            {
                var revenueData = revenueQuery.Where(a => a.AppointmentDate.Month == filterMonth.Value).ToList();
                var weeklyData = revenueData
                    .GroupBy(a => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(a.AppointmentDate, CalendarWeekRule.FirstDay, DayOfWeek.Sunday))
                    .ToDictionary(g => g.Key, g => g.Sum(a => a.TotalConsultedAmount));

                var weeksInMonth = Enumerable.Range(1, DateTime.DaysInMonth(filterYear, filterMonth.Value))
                    .Select(day => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(new DateTime(filterYear, filterMonth.Value, day), CalendarWeekRule.FirstDay, DayOfWeek.Sunday))
                    .Distinct().OrderBy(w => w).ToList();

                foreach (var weekNum in weeksInMonth)
                {
                    viewModel.ChartLabels.Add($"Week {weekNum}");
                    viewModel.RevenueData.Add(weeklyData.ContainsKey(weekNum) ? weeklyData[weekNum] : 0);
                }
            }
            else
            {
                var revenueData = revenueQuery.ToList();
                var monthlyData = revenueData
                    .GroupBy(a => a.AppointmentDate.Month)
                    .ToDictionary(g => g.Key, g => g.Sum(a => a.TotalConsultedAmount));

                for (int i = 1; i <= 12; i++)
                {
                    viewModel.ChartLabels.Add(CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[i - 1]);
                    viewModel.RevenueData.Add(monthlyData.ContainsKey(i) ? monthlyData[i] : 0);
                }
            }

            ViewBag.YearFilter = new SelectList(Enumerable.Range(today.Year - 5, 6).Reverse(), filterYear);
            var monthList = Enumerable.Range(1, 12).Select(m => new { Value = m, Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m) }).ToList();
            ViewBag.MonthFilter = new SelectList(monthList, "Value", "Text", filterMonth);
            ViewData["SelectedYear"] = filterYear;
            ViewData["SelectedMonth"] = filterMonth;

            return View(viewModel);
        }
    }
}