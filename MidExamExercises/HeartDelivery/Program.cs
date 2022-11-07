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
            int currentPosition = 0;

            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] command = input.Split(" ");
                
                int jump = int.Parse(command[1]);

                if (currentPosition + jump > neighborhood.Length - 1)
                {
                    currentPosition = 0;

                    if (neighborhood[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                    }
                    else
                    {
                        neighborhood[currentPosition] -= 2;

                        if (neighborhood[currentPosition] == 0)
                        {
                            Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                        }
                    }
                }

                else if (currentPosition + jump <= neighborhood.Length - 1)
                {
                    currentPosition += jump;

                    if (neighborhood[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                    }
                    else
                    {
                        neighborhood[currentPosition] -= 2;

                        if (neighborhood[currentPosition] == 0)
                        {
                            Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                        }
                    }
                }

            }

            int failedPlaces = 0;

            if (neighborhood.Sum() > 0)
            {
                for (int i = 0; i < neighborhood.Length; i++)
                {
                    if (neighborhood[i] > 0)
                    {
                        failedPlaces++;
                    }
                }

                Console.WriteLine($"Cupid's last position was {currentPosition}.");
                Console.WriteLine($"Cupid has failed {failedPlaces} places.");
                return;
            }

            else
            {
                Console.WriteLine($"Cupid's last position was {currentPosition}.");
                Console.WriteLine("Mission was successful.");
            }

        }
    }
}
