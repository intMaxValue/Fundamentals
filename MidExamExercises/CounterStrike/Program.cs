using System;
using System.Drawing;

namespace CounterStrike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse((Console.ReadLine()));
            string distance = Console.ReadLine();
            int battlesWon = 0;

            while (distance != "End of battle")
            {
                int energyNeeded = int.Parse(distance);

                if (energy < energyNeeded)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
                    return;
                }

                if ((battlesWon + 1) % 3 == 0 && battlesWon > 0)
                {
                    battlesWon++;
                    energy += battlesWon;
                    energy -= energyNeeded;
                    distance = Console.ReadLine();
                    continue;
                }

                energy -= energyNeeded;
                battlesWon++;

                distance = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");

        }
    }
}
