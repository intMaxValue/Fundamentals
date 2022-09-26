using System;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string money;
            double sum = 0;

            while ((money = Console.ReadLine()) != "Start")
            {
                double input = double.Parse(money);

                if (input == 0.1 || input == 0.2 || input == 0.5 || input == 1 || input == 2)
                {
                    sum += input;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {input}");
                }
            }

            string order;
            while ((order = Console.ReadLine()) != "End")
            {
                if (order == "Nuts" && sum >= 2.0)
                {
                    Console.WriteLine("Purchased nuts");
                    sum -= 2.0;
                    continue;
                }
                else if (order == "Nuts" && sum < 2.0)
                {
                    Console.WriteLine("Sorry, not enough money");
                    continue;
                }

                if (order == "Water" && sum >= 0.7)
                {
                    Console.WriteLine("Purchased water");
                    sum -= 0.7;
                    continue;
                }
                else if (order == "Water" && sum < 0.7)
                {
                    Console.WriteLine("Sorry, not enough money");
                    continue;
                }

                if (order == "Crisps" && sum >= 1.5)
                {
                    Console.WriteLine("Purchased crisps");
                    sum -= 1.5;
                    continue;
                }
                else if (order == "Crisps" && sum < 1.5)
                {
                    Console.WriteLine("Sorry, not enough money");
                    continue;
                }

                if (order == "Soda" && sum >= 0.8)
                {
                    Console.WriteLine("Purchased soda");
                    sum -= 0.8;
                    continue;
                }
                else if (order == "Soda" && sum < 0.8)
                {
                    Console.WriteLine("Sorry, not enough money");
                    continue;
                }

                if (order == "Coke" && sum >= 1.0)
                {
                    Console.WriteLine("Purchased coke");
                    sum -= 1.0;
                    continue;
                }
                else if (order == "Coke" && sum < 1.0)
                {
                    Console.WriteLine("Sorry, not enough money");
                    continue;
                }

                else
                {
                    Console.WriteLine("Invalid product");
                    continue;
                }
            }

            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}
