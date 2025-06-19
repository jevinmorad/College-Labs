using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    internal class InterfaceDemo
    {
        // Write a program to create interface Calculate. In this interface we have two member functions Addition() and Subtraction(). Implements this  in another class named Result.
        public interface Calculate
        {
            int Addition(int a, int b);
            int Subtraction(int a, int b);
        }

        public class Result : Calculate
        {
            public int Addition(int a, int b)
            {
                return a + b;
            }

            public int Subtraction(int a, int b)
            {
                return a - b;
            }
        }
    }
}
