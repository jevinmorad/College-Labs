using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    internal class AbstractDemo
    {
        // Write a program to create an abstract class Sum having abstract methods SumOfTwo(int a, int b) and SumOfThree(int a, int b, int c). Create another class Calculate which extends the abstract class and implements the abstract methods.
        public abstract class Sum
        {
            public abstract int SumOfTwo(int a, int b);
            public abstract int SumOfThree(int a, int b, int c);
        }
        public class Calculate : Sum
        {
            public override int SumOfTwo(int a, int b)
            {
                return a + b;
            }

            public override int SumOfThree(int a, int b, int c)
            {
                return a + b + c;
            }
        }
    }
}
