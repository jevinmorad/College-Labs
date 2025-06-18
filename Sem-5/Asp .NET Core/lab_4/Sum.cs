using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    internal class Sum
    {
        public void Add(int a, int b)
        {
            Console.WriteLine($"Sum of integers: {a + b}");
        }
        public void Add(float a, float b)
        {
            Console.WriteLine($"Sum of floats: {a + b}");
        }
    }
}
