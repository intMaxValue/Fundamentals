using System;

namespace PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyAvailable = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lightsabersMoneyNeeded = lightsaberPrice * (Math.Ceiling(students * 1.1));
            double robesMoneyNeeded = robePrice * students;

            double beltDiscount = 0;

            if (students >= 6)
            {
                beltDiscount = students / 6;

            }
            double beltsMoneyNeeded = beltPrice * (students - beltDiscount);

            double totalMoneyNeeded = lightsabersMoneyNeeded + robesMoneyNeeded + beltsMoneyNeeded;

            if (moneyAvailable >= totalMoneyNeeded)
            {
                Console.WriteLine($"The money is enough - it would cost {totalMoneyNeeded:F2}lv.");
            }
            else if (moneyAvailable < totalMoneyNeeded)
            {
                Console.WriteLine($"John will need {totalMoneyNeeded - moneyAvailable:F2}lv more.");
            }
        }
    }
}
