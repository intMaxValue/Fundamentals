using System;

namespace WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] cmnd = input.Split(":");
                string action = cmnd[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(cmnd[1]);
                    string stop = cmnd[2];

                    if (index >= 0 && index < start.Length)
                    {
                        start = start.Insert(index, stop);
                    }

                    Console.WriteLine(start);
                }

                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(cmnd[1]);
                    int endIndex = int.Parse(cmnd[2]);

                    if (startIndex >= 0 && endIndex < start.Length )
                    {
                        start = start.Remove(startIndex,1 + endIndex - startIndex);
                    }

                    Console.WriteLine(start);
                }

                else if (action == "Switch")
                {
                    string oldString = cmnd[1];
                    string newString = cmnd[2];

                    if (start.Contains(oldString))
                    {
                        start = start.Replace(oldString, newString);
                    }

                    Console.WriteLine(start);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {start}");
        }
    }
}
