using System;
using System.Linq;
using System.Collections.Generic;

namespace ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];
                if (action == "swap" || action == "multiply")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    int firstIndexElement = elements[index1];

                    if (action == "swap")
                    {
                        firstIndexElement = elements[index2];
                        elements[index2] = elements[index1];
                        elements[index1] = firstIndexElement;
                    }

                    else if (action == "multiply")
                    {
                        elements[index1] *= elements[index2];
                    }

                }

                else if (action == "decrease")
                {
                    for (int i = 0; i < elements.Length; i++)
                    {
                        elements[i] -= 1;
                    }
                }
            }

            Console.WriteLine(String.Join(", ", elements));
        }
    }
}
