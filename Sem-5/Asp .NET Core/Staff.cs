using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class Staff
    {
        string Name;
        string Department;
        String Designation;
        float Experience;
        float Salary;

        public void GetStaffDetails()
        {
            Console.Write("\n\nEnter staff name: ");
            Name = Console.ReadLine();
            Console.Write("Enter staff department: ");
            Department = Console.ReadLine();
            Console.Write("Enter staff designation: ");
            Designation = Console.ReadLine();
            Console.Write("Enter staff experience (in years): ");
            Experience = float.Parse(Console.ReadLine());
            Console.Write("Enter staff salary: ");
            Salary = float.Parse(Console.ReadLine());
        }

        public void DisplayStaffDetails()
        {
            if (Department == "HR")
            {
                Console.WriteLine($"\n------HR Department-----\n Staff Name: {Name}\n Salary: ${Salary}");
            }
        }
    }
}
