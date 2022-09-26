using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double pricePerPerson = 0;
            double totalPrice = 0;

            if (groupType == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    pricePerPerson = 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    pricePerPerson = 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    pricePerPerson = 10.46;
                }

            }

            else if (groupType == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    pricePerPerson = 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    pricePerPerson = 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    pricePerPerson = 16;
                }
            }

            else if (groupType == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    pricePerPerson = 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    pricePerPerson = 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    pricePerPerson = 22.50;
                }
            }

            totalPrice = pricePerPerson * peopleCount;

            if (groupType == "Students" && peopleCount >= 30)
            {
                totalPrice *= 0.85;
            }

            if (groupType == "Business" && peopleCount >= 100)
            {
                totalPrice -= pricePerPerson * 10;
            }

            if (groupType == "Regular" && peopleCount >= 10 && peopleCount <= 20)
            {
                totalPrice *= 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");

        }
    }
}
