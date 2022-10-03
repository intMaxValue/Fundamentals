using System;

namespace SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int employee1Efficiency = int.Parse(Console.ReadLine());
            int employee2Efficiency = int.Parse(Console.ReadLine());
            int employee3Efficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int totalEfficiencyPerHour = employee1Efficiency + employee2Efficiency + employee3Efficiency;
            int hours = 0;

            while (studentsCount > 0)
            {
                studentsCount -= totalEfficiencyPerHour;
                hours++;
                if (hours % 4 == 0)
                {
                    hours++;

                }

            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
