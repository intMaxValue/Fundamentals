using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppngList = Console.ReadLine().Split("!").ToList();
            string input = "";

            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                List<string> command = input.Split().ToList();

                if (command[0] == "Urgent" && !shoppngList.Contains(command[1]))
                {
                    shoppngList.Insert(0, command[1]);
                    continue;
                }

                if (command[0] == "Unnecessary" && shoppngList.Contains(command[1]))
                {
                    shoppngList.Remove(command[1]);
                    continue;
                }

                if (command[0] == "Correct" && shoppngList.Contains(command[1]))
                {
                    int indexOfItem = shoppngList.IndexOf(command[1]);
                    shoppngList.RemoveAt(indexOfItem);
                    shoppngList.Insert(indexOfItem, command[2]);
                    continue;
                }

                if (command[0] == "Rearrange" && shoppngList.Contains(command[1]))
                {
                    shoppngList.Add(command[1]);
                    shoppngList.Remove(command[1]);
                }
            }

            Console.WriteLine(string.Join(", ", shoppngList));
        }
    }
}
