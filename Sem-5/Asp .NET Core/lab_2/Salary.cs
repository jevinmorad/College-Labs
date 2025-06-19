using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class Salary
    {
        double Basic;
        double TA;
        double DA;
        double HRA;

        public Salary(double basic, double ta, double da = 0.10, double hra = 0.15)
        {
            Basic = basic;
            TA = ta;
            DA = da * Basic;
            HRA = hra * Basic;
        }

        public void CalculateSalary()
        {
            double totalSalary = Basic + TA + DA + HRA;
            Console.WriteLine("\n--- Salary Details ---");
            Console.WriteLine("Basic Salary: " + Basic);
            Console.WriteLine("Travel Allowance (TA): " + TA);
            Console.WriteLine("Dearness Allowance (DA): " + DA);
            Console.WriteLine("House Rent Allowance (HRA): " + HRA);
            Console.WriteLine("Total Salary: " + totalSalary);
        }
    }
}
