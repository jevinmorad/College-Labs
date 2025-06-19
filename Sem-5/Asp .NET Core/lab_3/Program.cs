// Replace 'use AbstractDemo;' with 'using AbstractDemo;' to fix the CS0246 error.  
using lab_3;
using System.ComponentModel;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

while (true)
{
    Console.Write("\nEnter a program number: ");
    int n = int.Parse(Console.ReadLine());
    switch (n) {
        case 1:
            // Write a program to Create a divide by zero exception and handle it. 
            try 
            {
                int x = 10;
                int y = 0;
                Console.WriteLine(x/y);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: "+ex.Message);
            }
            break;

        case 2:
            // Write a program that reads 5 numbers from user. Demonstrate concept of IndexOutOfRange Exception.
            try 
            {
                int[] numbers = new int[5];
                for (int i = 0; i <= 5; i++) // Intentionally going out of bounds
                {
                    Console.Write($"Enter number {i + 1}: ");
                    numbers[i] = int.Parse(Console.ReadLine());
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            break;

        case 3:
            AbstractDemo.Calculate cal = new();
            Console.WriteLine(cal.SumOfTwo(1, 3));
            Console.WriteLine(cal.SumOfThree(1, 3, 4));
            break;

        case 4:
            InterfaceDemo.Result res = new();
            Console.WriteLine(res.Addition(1, 2));
            Console.WriteLine(res.Subtraction(2, 4));
            break;

        case 5:
            // Write program showing use of common methods of String class.
            string str = "\n  Hello, World!  ";
            Console.WriteLine($"Original string: '{str}'");

            string trimmed = str.Trim();
            Console.WriteLine($"Trimmed: '{trimmed}'");

            Console.WriteLine($"ToUpper: {trimmed.ToUpper()}");
            Console.WriteLine($"ToLower: {trimmed.ToLower()}");

            Console.WriteLine($"Substring (start at 7): {trimmed.Substring(7)}");

            Console.WriteLine($"Replace 'World' with 'C#': {trimmed.Replace("World", "C#") }");

            Console.WriteLine($"Contains 'Hello': {trimmed.Contains("Hello")}");

            Console.WriteLine($"IndexOf ',': {trimmed.IndexOf(',') }");

            string[] parts = trimmed.Split(',');
            Console.WriteLine("Split by ',' :");
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }
            break;

        case 6:
            // Write a program to Replace lower case characters to upper case and Vice-versa
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            char[] swapped = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsLower(c))
                    swapped[i] = char.ToUpper(c);
                else if (char.IsUpper(c))
                    swapped[i] = char.ToLower(c);
                else
                    swapped[i] = c;
            }

            string result = new string(swapped);
            Console.WriteLine($"Swapped case: {result}");
            break;

        case 7:
            InterfaceShape.AreaCalculator areaCalculator = new();
            Console.WriteLine("Circle area with r = 2 is "+areaCalculator.Circle(2));
            Console.WriteLine("Triangle area with base = 1, height = 3 is "+areaCalculator.Triangle(1, 3));
            Console.WriteLine("Square area with lenght = 2 is "+areaCalculator.Square(2));
            break;

        case 8:
            // Write a program to accept a number from the user and throw an exception if the number is not an even number.
            try
            {
                Console.Write("Enter an even number: ");
                int number = int.Parse(Console.ReadLine());
                if (number % 2 != 0)
                {
                    throw new Exception("The number is not even.");
                }
                Console.WriteLine("You entered an even number: " + number);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            break;

        case 9:
            //  Write a program to find the longest word in a string.
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(' ');
            string longestWord = words.OrderByDescending(w => w.Length).FirstOrDefault();
            Console.WriteLine("Longest word: " + longestWord);
            break;

        case 10:
            //  Write a program to change the case of entered character.
            Console.Write("Enter a character: ");
            char character = Console.ReadKey().KeyChar;
            Console.WriteLine(char.IsUpper(character) ? 
                $"\nLowercase: {char.ToLower(character)}" : 
                $"\nUppercase: {char.ToUpper(character)}");
            break;

        default:
        Console.WriteLine("Invalid program number.");
        return 0;
    }
}