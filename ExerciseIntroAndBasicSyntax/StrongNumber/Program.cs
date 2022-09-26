using System;

namespace StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int inputOg = input;
            int currentNum = 0;
            int currSum = 1;
            int totalSum = 0;

            while (input != 0)
            {
                currentNum = input % 10;

                for (int i = 1; i <= currentNum ; i++)
                {
                    currSum *= i;
                }
                totalSum += currSum;
                input = input / 10;
                currSum = 1;
            }

            if (totalSum == inputOg)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
