using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Controllers
{
    [CheckAccess]
    public class EmployeeController : Controller
    {
        #region Configuration
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region List
        public IActionResult List()
        {
            string ConnectionString = this._configuration.GetConnectionString(name: "EmployeeConnectionString");
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "PR_Employee_SelectAll";
            using SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            return View(table);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View(new Employee());
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            string ConnectionString = this._configuration.GetConnectionString(name: "EmployeeConnectionString");
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Employee_Insert";
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", employee.Gender);
            command.Parameters.AddWithValue("@HireDate", employee.HireDate);
            command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            command.Parameters.AddWithValue("@Department", employee.Department);
            command.Parameters.AddWithValue("@Salary", employee.Salary);
            command.Parameters.AddWithValue("@IsActive", employee.IsActive);
            command.ExecuteNonQuery();
            return RedirectToAction("List");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string connectionString = this._configuration.GetConnectionString(name: "EmployeeConnectionString");
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Employee employee = new Employee();

            using SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Employee_SelectByID";
            command.Parameters.AddWithValue("@EmployeeId", id);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.Email = reader["Email"].ToString();
                employee.PhoneNumber = reader["PhoneNumber"].ToString();
                employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                employee.Gender = reader["Gender"].ToString();
                employee.HireDate = Convert.ToDateTime(reader["HireDate"]);
                employee.JobTitle = reader["JobTitle"].ToString();
                employee.Department = reader["Department"].ToString();
                employee.Salary = Convert.ToDecimal(reader["Salary"]);
                employee.IsActive = Convert.ToBoolean(reader["IsActive"]);
                employee.UpdatedAt = DateTime.Now;

                return View("Create", employee);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (employee.EmployeeId == 0)
            {
                return NotFound();
            }
            if (!ModelState.IsValid) {
                return View("Create", employee);
            }
            string connectionString = this._configuration.GetConnectionString(name: "EmployeeConnectionString");
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Employee_Update";
            command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", employee.Gender);
            command.Parameters.AddWithValue("@HireDate", employee.HireDate);
            command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            command.Parameters.AddWithValue("@Department", employee.Department);
            command.Parameters.AddWithValue("@Salary", employee.Salary);
            command.Parameters.AddWithValue("@IsActive", employee.IsActive);

            command.ExecuteNonQuery();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string connectionString = this._configuration.GetConnectionString(name: "EmployeeConnectionString");
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Employee_Delete";
            command.Parameters.AddWithValue("EmployeeId", id);
            command.ExecuteNonQuery();

            return RedirectToAction("List");
        }
        #endregion
    }
}