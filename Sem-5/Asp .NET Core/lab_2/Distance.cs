using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class Distance
    {
        double dist1;
        double dist2;
        double dist3;

        public Distance(double d1, double d2)
        {
            dist1 = d1;
            dist2 = d2;
        }

        public void AddDistances()
        {
            dist3 = dist1 + dist2;
        }

        public void DisplayDistance()
        {
            Console.WriteLine("Distance 1: " + dist1);
            Console.WriteLine("Distance 2: " + dist2);
            Console.WriteLine("Total Distance: " + dist3);
        }
    }
}
