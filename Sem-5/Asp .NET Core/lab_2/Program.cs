using lab_2;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Principal;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

// Lab 2 - Candidate Management System
//Candidate candidate = new Candidate();
//candidate.GetCandidateDetails();
//candidate.DisplayCandidateDetails();

// lab 2 - Bank Account Management System
//BankAccount bankAccount = new BankAccount();
//bankAccount.GetAccountDetails();
//bankAccount.DisplayAccountDetails();

// lab 2 - Staff Management System
//Staff[] staff = new Staff[2];
//for (int i = 0; i < staff.Length; i++)
//{
//    staff[i] = new Staff();
//    staff[i].GetStaffDetails();
//}
//for (int i = 0; i < staff.Length; i++)
//{
//    staff[i].DisplayStaffDetails();
//}

// lab 2 - Student Management System
//Student student = new Student(101, "John Doe", 5, 8.5f, 9.0f);
//student.DisplayStudentDetails();

// Lab - 2 - Rectangle Area Calculation
//Rectangle rectangle = new Rectangle(5, 10);
//Console.WriteLine($"Area of the rectangle: {rectangle.Area()}");

// Write a program for implementing single inheritance which creates one class Account_Details for getting account information and another Interest for calculating and displaying total interest from the data from account details. 
//Interest obj = new Interest();
//obj.GetDetails();
//obj.CalculateInterest();
//obj.DisplayInterest();

// Write a program to Define a class Salary which will contain member variable Basic, TA, DA, HRA. Write a program using Constructor with default values for DA and HRA and calculate the salary of employee.
//Console.Write("Enter Basic Salary: ");
//double basic = Convert.ToDouble(Console.ReadLine());
//Console.Write("Enter Travel Allowance (TA): ");
//double ta = Convert.ToDouble(Console.ReadLine());
//Salary empSalary = new Salary(basic, ta);
//empSalary.CalculateSalary();

// Write a program to Define a class Distance have data members dist1, dist2, dist3.Initialize the two data members using constructor and store their addition in third data member using function and display addition.
//Console.Write("Enter Distance 1: ");
//double d1 = Convert.ToDouble(Console.ReadLine());

//Console.Write("Enter Distance 2: ");
//double d2 = Convert.ToDouble(Console.ReadLine());

//Distance obj = new Distance(d1, d2);
//obj.AddDistances();
//obj.DisplayDistance();

// Create a class Furniture with material ,price as data members. Create another class Table with Height, surface_area as data members. Write a program to implement single inheritance.
Table obj = new Table();
obj.GetFurnitureDetails();
obj.GetTableDetails();
obj.DisplayDetails();
