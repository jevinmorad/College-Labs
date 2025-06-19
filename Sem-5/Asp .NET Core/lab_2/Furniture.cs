using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class Furniture
    {
        protected string material;
        protected double price;

        public void GetFurnitureDetails()
        {
            Console.Write("Enter Material: ");
            material = Console.ReadLine();

            Console.Write("Enter Price: ");
            price = Convert.ToDouble(Console.ReadLine());
        }
    }

    class Table : Furniture
    {
        double height;
        double surface_area;

        public void GetTableDetails()
        {
            Console.Write("Enter Height: ");
            height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Surface Area: ");
            surface_area = Convert.ToDouble(Console.ReadLine());
        }

        public void DisplayDetails()
        {
            Console.WriteLine("\n--- Table Details ---");
            Console.WriteLine("Material: " + material);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Height: " + height);
            Console.WriteLine("Surface Area: " + surface_area);
        }
    }
}
