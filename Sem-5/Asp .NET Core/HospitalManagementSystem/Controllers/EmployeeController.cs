﻿using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Controllers
{
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
            string ConnectionString = this._configuration.GetConnectionString(name: "TimeWasteConnectionString");
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
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.CreatedAt = DateTime.Now;
            employee.UpdatedAt = DateTime.Now;

            string ConnectionString = this._configuration.GetConnectionString(name: "TimeWasteConnectionString");
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
            command.Parameters.AddWithValue("@Gender", employee.Salary);
            command.Parameters.AddWithValue("@HireDate", employee.HireDate);
            command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            command.Parameters.AddWithValue("@Department", employee.Department);
            command.Parameters.AddWithValue("@Salary", employee.Salary);
            command.Parameters.AddWithValue("@IsActive", employee.IsActive);
            command.Parameters.AddWithValue("@UpdatedAt", employee.UpdatedAt);
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
            string connectionString = this._configuration.GetConnectionString(name: "TimeWasteConnectionString");
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

                return View("List");
            }
            return View();
        }
        #endregion
    }
}