using System;

namespace SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = new string[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Console.ReadLine();
            }
            Array.Sort(numbers);
            Array.Reverse(numbers);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
