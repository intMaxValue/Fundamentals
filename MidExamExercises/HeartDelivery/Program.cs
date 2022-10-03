using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            string input = "";
            int currPositionIndex = 0;
            int housesLeftUnloved = 0;

            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] command = input.Split().ToArray();
                int jump = int.Parse(command[1]);

                if (currPositionIndex + jump > neighborhood.Length - 1)
                {
                    currPositionIndex = 0;
                    if (neighborhood[0] == 0)
                    {
                        Console.WriteLine($"Place {neighborhood[0]} already had Valentine's day.");
                        continue;
                    }
                    else if (neighborhood[0] > 0)
                    {
                        neighborhood[0] -= 2;
                        if (neighborhood[0] == 0)
                        {
                            Console.WriteLine($"Place {neighborhood[0]} has Valentine's day.");

                        }
                    }
                }

                else if (currPositionIndex + jump <= neighborhood.Length - 1)
                {
                    currPositionIndex += jump;

                    if (neighborhood[currPositionIndex] == 0)
                    {
                        Console.WriteLine($"Place {neighborhood[currPositionIndex]} already had Valentine's day.");
                        continue;
                    }
                    else if (neighborhood[0] > 0)
                    {
                        neighborhood[currPositionIndex] -= 2;
                        if (neighborhood[currPositionIndex] == 0)
                        {
                            Console.WriteLine($"Place {currPositionIndex} has Valentine's day.");

                        }
                    }
                }


            }

            Console.WriteLine($"Cupid's last position was {currPositionIndex}.");

            if (neighborhood.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
                return;
            }
            else
            {
                for (int i = 0; i < neighborhood.Length; i++)
                {
                    if (neighborhood[i] > 0)
                    {
                        housesLeftUnloved++;
                    }
                }
                Console.WriteLine($"Cupid has failed {housesLeftUnloved} places.");
            }

        }
    }
}
