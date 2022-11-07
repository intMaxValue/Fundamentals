using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();

            string input = "";

            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] item = input.Split(" - ");

                if (item[0] == "Collect")
                {
                    if (items.Contains(item[1]))
                    {
                        continue;
                    }

                    items.Add(item[1]);
                }
                else if (item[0] == "Drop")
                {
                    if (items.Contains(item[1]))
                    {
                        items.Remove(item[1]);
                    }

                }
                else if (item[0] == "Combine Items")
                {
                    string[] combine = item[1].Split(":");
                    string oldItem = combine[0];
                    string newItem = combine[1];

                    if (items.Contains(oldItem))
                    {
                        int oldItemIndex = items.IndexOf(oldItem);
                        items.Insert(oldItemIndex + 1, newItem);
                    }
                }
                else if (item[0] == "Renew")
                {
                    if (items.Contains(item[1]))
                    {
                        int indexOfItem = items.IndexOf(item[1]);
                        items.Add(item[1]);
                        items.Remove(item[1]);
                    }
                }
                
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
