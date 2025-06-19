using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    internal class InterfaceShape
    {
        // Write a program to create interface named Shape. In this interface, we have three methods Circle(), Triangle() and Square() which calculates area of Circle, Triangle and Square respectively. Implement Shape interface
        public interface Shape
        {
            double Circle(double radius);
            double Triangle(double @base, double height);
            double Square(double side);
        }

        public class AreaCalculator : Shape
        {
            public double Circle(double radius)
            {
                return Math.PI * radius * radius;
            }

            public double Triangle(double @base, double height)
            {
                return 0.5 * @base* height;
            }

            public double Square(double side)
            {
                return side * side;
            }
        }
    }
}
