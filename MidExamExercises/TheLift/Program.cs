using System;
using System.Linq;

namespace TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int totalCapacity = (wagons.Length * 4) - wagons.Sum();

            for (int i = 0; i < wagons.Length; i++)
            {
                int wagonCapacity = 4 - wagons[i];

                if (wagonCapacity > 0 && people > 0 && totalCapacity > 0)
                {
                    for (int j = 0; j < wagonCapacity; j++)
                    {
                        wagons[i]++;
                        people--;
                        totalCapacity--;

                        if (totalCapacity == 0 || people == 0)
                        {
                            break;
                        }
                    }

                }

            }

            if (people == 0 && totalCapacity > 0)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(String.Join(" ", wagons));
            }
            else if (people > 0 && totalCapacity == 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(String.Join(" ", wagons));
            }
            else if (people == 0 && totalCapacity == 0)
            {
                Console.WriteLine(String.Join(" ", wagons));
            }
        }
    }
}
