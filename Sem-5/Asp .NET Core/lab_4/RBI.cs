using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    internal abstract class RBI
    {
        public abstract void CalculateInterest(double amount, double duration); // Marked as abstract  
    }

    class HDFC : RBI
    {
        public override void CalculateInterest(double amount, double duration)
        {
            double interest = (amount * 0.875 * duration) / 100;
            Console.WriteLine($"HDFC Interest: {interest}");
        }
    }

    class SBI : RBI
    {
        public override void CalculateInterest(double amount, double duration)
        {
            double interest = (amount * 0.7 * duration) / 100;
            Console.WriteLine($"SBI Interest: {interest}");
        }
    }

    class ICICI : RBI
    {
        public override void CalculateInterest(double amount, double duration)
        {
            double interest = (amount * 1.5 * duration) / 100;
            Console.WriteLine($"ICICI Interest: {interest}");
        }
    }
}
