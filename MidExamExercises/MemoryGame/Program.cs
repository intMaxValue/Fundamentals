using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> Elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int moves = 0;

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                int[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


                if (Elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    return;
                }

                moves++;



                if ((inputArr[0] < 0 || inputArr[1] < 0)
                    || (inputArr[0] > Elements.Count - 1) || (inputArr[1] > Elements.Count - 1)
                    || inputArr[0] == inputArr[1])
                {
                    string insertElement = $"-{moves}a";
                    Elements.Insert(Elements.Count / 2, insertElement);
                    Elements.Insert(Elements.Count / 2, insertElement);

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }

                else if (Elements[inputArr[0]] == Elements[inputArr[1]])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {Elements[inputArr[1]]}!");
                    string removeElement = Elements[inputArr[0]];
                    Elements.Remove(removeElement);
                    Elements.Remove(removeElement);
                    continue;
                }

                if (Elements[inputArr[0]] != Elements[inputArr[1]])
                {
                    Console.WriteLine("Try again!");
                    continue;
                }
            }

            if (input == "end" && Elements.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", Elements));
            }
        }
    }
}
