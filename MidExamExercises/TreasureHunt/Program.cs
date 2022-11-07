using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|").ToList();
            string input = "";

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                List<string> command = input.Split().ToList();

                if (command[0] == "Loot")
                {
                    List<string> lootItems = command;
                    lootItems.Remove("Loot");

                    for (int i = 0; i < lootItems.Count; i++)
                    {
                        if (chest.Contains(lootItems[i]))
                        {
                            continue;
                        }
                        chest.Insert(0, lootItems[i]);
                    }
                }
                else if (command[0] == "Drop")
                {
                    if (int.Parse(command[1]) > chest.Count - 1
                        || int.Parse(command[1]) < 0)
                    {
                        continue;
                    }

                    int indexOfItem = int.Parse(command[1]);
                    string item = chest[indexOfItem];
                    chest.Add(item);
                    chest.Remove(item);
                }
                else if (command[0] == "Steal")
                {
                    List<string> removedItems = new List<string>();

                    if (int.Parse(command[1]) >= chest.Count)
                    {
                        Console.WriteLine(string.Join(", ", chest));
                        chest.Clear();
                        continue;
                    }

                    for (int i = 0; i < int.Parse(command[1]); i++)
                    {
                        removedItems.Add(chest[chest.Count - 1]);
                        chest.Remove(chest[chest.Count - 1]);
                    }

                    removedItems.Reverse();
                    Console.WriteLine(string.Join(", ", removedItems));
                }
            }

            if (chest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double itemsCount = chest.Count;
                char[] charSum = string.Join("", chest).ToCharArray();
                double averageGain = charSum.Length / itemsCount;

                Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
            }
        }
    }
}
