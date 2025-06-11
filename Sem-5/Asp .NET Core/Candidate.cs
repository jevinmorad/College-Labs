using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class Candidate
    {
        int Id;
        string Name;
        int Age;
        float Weight;
        float Height;

        public void GetCandidateDetails()
        {
            Console.Write("Enter candidate id: ");
            Id = int.Parse(Console.ReadLine());

            Console.Write("Enter candidate name: ");
            Name = Console.ReadLine();

            Console.Write("Enter candidate age: ");
            Age = int.Parse(Console.ReadLine());

            Console.Write("Enter candidate weight: ");
            Weight = float.Parse(Console.ReadLine());

            Console.Write("Enter candidate height: ");
            Height = float.Parse(Console.ReadLine());
        }

        public void DisplayCandidateDetails()
        {
            Console.WriteLine($"\n--------Candidate details---------\n Id: {Id}\n Name: {Name}\n Age: {Age}\n Weight: {Weight}\n Height: {Height}");
        }
    }
}
