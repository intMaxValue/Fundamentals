using System;

namespace SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int consumed = 26;
            int spiceLeft = 0;
            int days = 0;

            if (startingYield < 100)
            {
                Console.WriteLine("0");
                Console.WriteLine(spiceLeft);
                return;
            }

            while (startingYield >= 100)
            {
                spiceLeft += startingYield - consumed;

                days++;
                startingYield -= 10;
            }

            
            Console.WriteLine(days);
            Console.WriteLine(spiceLeft - consumed);
        }
    }
}
