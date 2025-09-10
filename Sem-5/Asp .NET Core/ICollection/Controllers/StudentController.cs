using ICollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ICollection.Controllers
{
    public class StudentController : Controller
    {
        private readonly string _connectionString;

        public StudentController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            List<StudentModel> students = new List<StudentModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_Student_SelectAll", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        students.Add(new StudentModel
                        {
                            EnrollmentNo = Convert.ToInt32(rdr["EnrollmentNo"]),
                            Name = rdr["Name"].ToString(),
                            MobileNo = rdr["MobileNo"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Address = rdr["Address"].ToString(),
                            Gender = rdr["Gender"].ToString(),
                            PlayingCricket = Convert.ToBoolean(rdr["PlyingCricket"]),
                            Percentage12 = Convert.ToDouble(rdr["percentage_12"]),
                            LiveInRajkot = Convert.ToBoolean(rdr["LiveInRajkot"])
                        });
                    }
                }
            }
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_Student_Insert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", studentModel.Name);
                        cmd.Parameters.AddWithValue("@MobileNo", studentModel.MobileNo);
                        cmd.Parameters.AddWithValue("@Email", studentModel.Email);
                        cmd.Parameters.AddWithValue("@Address", studentModel.Address);
                        cmd.Parameters.AddWithValue("@Gender", studentModel.Gender);
                        cmd.Parameters.AddWithValue("@PlyingCricket", studentModel.PlayingCricket);
                        cmd.Parameters.AddWithValue("@password", studentModel.Password);
                        cmd.Parameters.AddWithValue("@ConfirmPassword", studentModel.ConfirmPassword);
                        cmd.Parameters.AddWithValue("@percentage_12", studentModel.Percentage12);
                        cmd.Parameters.AddWithValue("@LiveInRajkot", studentModel.LiveInRajkot);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            StudentModel student = GetStudentById(id.Value);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, StudentModel studentModel)
        {
            if (id != studentModel.EnrollmentNo) return NotFound();

            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_Student_UpdateByPK", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EnrollmentNo", studentModel.EnrollmentNo);
                        cmd.Parameters.AddWithValue("@Name", studentModel.Name);
                        cmd.Parameters.AddWithValue("@MobileNo", studentModel.MobileNo);
                        cmd.Parameters.AddWithValue("@Email", studentModel.Email);
                        cmd.Parameters.AddWithValue("@Address", studentModel.Address);
                        cmd.Parameters.AddWithValue("@Gender", studentModel.Gender);
                        cmd.Parameters.AddWithValue("@PlyingCricket", studentModel.PlayingCricket);
                        cmd.Parameters.AddWithValue("@password", studentModel.Password);
                        cmd.Parameters.AddWithValue("@ConfirmPassword", studentModel.ConfirmPassword);
                        cmd.Parameters.AddWithValue("@percentage_12", studentModel.Percentage12);
                        cmd.Parameters.AddWithValue("@LiveInRajkot", studentModel.LiveInRajkot);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            StudentModel student = GetStudentById(id.Value);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_Student_DeleteByPK", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnrollmentNo", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private StudentModel GetStudentById(int id)
        {
            StudentModel student = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_Student_SelectByPK", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnrollmentNo", id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        student = new StudentModel
                        {
                            EnrollmentNo = Convert.ToInt32(rdr["EnrollmentNo"]),
                            Name = rdr["Name"].ToString(),
                            MobileNo = rdr["MobileNo"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Address = rdr["Address"].ToString(),
                            Gender = rdr["Gender"].ToString(),
                            PlayingCricket = Convert.ToBoolean(rdr["PlyingCricket"]),
                            Password = rdr["password"].ToString(),
                            ConfirmPassword = rdr["ConfirmPassword"].ToString(),
                            Percentage12 = Convert.ToDouble(rdr["percentage_12"]),
                            LiveInRajkot = Convert.ToBoolean(rdr["LiveInRajkot"])
                        };
                    }
                }
            }
            return student;
        }
    }
}