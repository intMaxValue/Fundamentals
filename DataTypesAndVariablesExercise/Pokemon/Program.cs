using System;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nPower = int.Parse(Console.ReadLine());
            int mDistance = int.Parse(Console.ReadLine());
            int yExhaustion = int.Parse(Console.ReadLine());
            int nInitial = nPower;
            int targetsPoked = 0;

            while (nPower >= mDistance)
            {
                nPower -= mDistance;
                targetsPoked++;

                if (nInitial / 2 == nPower && yExhaustion != 0)
                {
                    nPower /= yExhaustion;
                }
            }

            Console.WriteLine(nPower);
            Console.WriteLine(targetsPoked);
        }
    }
}
