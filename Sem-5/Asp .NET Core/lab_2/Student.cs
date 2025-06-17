using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class Student
    {
        public int Enrollment_No;
        public string Student_Name;
        public int Semester;
        public float CPI;
        public float SPI;

        public Student(int enrollmentNo, string name, int semester, float cpi, float spi)
        {
            Enrollment_No = enrollmentNo;
            Student_Name = name;
            Semester = semester;
            CPI = cpi;
            SPI = spi;
        }

        public void DisplayStudentDetails()
        {
            Console.WriteLine($"Enrollment No: {Enrollment_No}, Name: {Student_Name}, Semester: {Semester}, CPI: {CPI}, SPI: {SPI}");
        }
    }
}
