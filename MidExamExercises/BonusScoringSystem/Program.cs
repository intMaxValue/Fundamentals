using System;

namespace BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            double numberOfLectures = double.Parse(Console.ReadLine());
            double bonus = double.Parse(Console.ReadLine());
            int bestAttendance = 0;
            int maxBonus = 0;


            for (int i = 0; i < numberOfStudents; i++)
            {
                int attendance = int.Parse(Console.ReadLine());

                double currBonus = attendance / numberOfLectures * (5 + bonus);

                if (currBonus > maxBonus)
                {
                    maxBonus = (int)Math.Round(currBonus);
                    bestAttendance = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {bestAttendance} lectures.");

        }
    }
}
