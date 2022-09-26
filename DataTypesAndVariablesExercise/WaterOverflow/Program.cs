using System;

namespace WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxCapacity = 255;
            int currCapacity = 0;

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if ((currCapacity + input) > maxCapacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else if (input < maxCapacity && currCapacity < maxCapacity)
                { 
                    currCapacity += input;
                }

            }
            Console.WriteLine(currCapacity);
        }
    }
}
