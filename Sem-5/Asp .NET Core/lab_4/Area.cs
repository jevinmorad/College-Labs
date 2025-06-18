using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    internal class Area
    {
        public void CalculateArea(double length)
        {
            Console.WriteLine($"Area of rectangle: {length * length}");
        }
        public void CalculateArea(double width, double height)
        {
            Console.WriteLine($"Area of triangle: {0.5 * width * height}");
        }
    }
}
