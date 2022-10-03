using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            double average = Math.Round((double)elements.Sum() / elements.Count);

            List<int> result = new List<int>();

            bool isHoldingBiggerElement = false;

            foreach (int element in elements)
            {
                if (element > average)
                {
                    result.Add(element);
                    isHoldingBiggerElement = true;
                }
            }

                if (!isHoldingBiggerElement)
                {
                    Console.WriteLine("No");
                    return;
                }

            result.Sort();
            result.Reverse();
            while (result.Count > 5)
            {
                result.RemoveAt(result.Count - 1);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
