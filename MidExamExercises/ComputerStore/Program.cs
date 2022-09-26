using System;
using System.Diagnostics;

namespace ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double sum = 0;
            double taxes = 0;

            while ((input = Console.ReadLine()) != "special" && input != "regular")
            {
                double currentPart = double.Parse(input);

                if (currentPart <= 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                sum += currentPart;
            }

            if (sum > 0)
            {
                taxes = sum * 0.2;
            }
            else
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double total =  sum + taxes;

            if (input == "special")
            {
                total *= 0.9;
            }

            Console.WriteLine($"Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {sum:F2}$");
            Console.WriteLine($"Taxes: {taxes:F2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {total:F2}$");



        }
    }
}
