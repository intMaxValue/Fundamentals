using System;

namespace RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double headsetTotal = (lostGames / 2) * headsetPrice;
            double mouseTotal = (lostGames / 3) * mousePrice;
            double keyboardTotal = (lostGames / 6) * keyboardPrice;
            double displayTotal = (lostGames / 12) * displayPrice;

            double total = headsetTotal + mouseTotal + keyboardTotal + displayTotal;

            Console.WriteLine($"Rage expenses: {total:F2} lv.");

        }
    }
}
