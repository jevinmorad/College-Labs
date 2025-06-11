using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class Rectangle
    {
        public double Length;
        public double Breadth;

        public Rectangle(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public double Area()
        {
            return Length * Breadth;
        }
    }
}
