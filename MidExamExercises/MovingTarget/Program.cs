using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputSplit = input.Split(" ").ToArray();

                string command = inputSplit[0];
                int index = int.Parse(inputSplit[1]);
                int value = int.Parse(inputSplit[2]);

                if (command == "Shoot")
                {
                    if (index < 0 || index > targets.Count - 1)
                    {
                        continue;
                    }

                    targets[index] -= value;

                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }
                }

                else if (command == "Add")
                {
                    if (index < 0 || index > targets.Count - 1)
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }

                    targets.Insert(index, value);
                }

                else if (command == "Strike")
                {
                    if ((index - value) < 0 || index + value > targets.Count - 1)
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }

                    targets.RemoveRange(index - value, (value * 2) + 1);
                }

            }

            Console.WriteLine(string.Join("|", targets));

        }
    }
}
