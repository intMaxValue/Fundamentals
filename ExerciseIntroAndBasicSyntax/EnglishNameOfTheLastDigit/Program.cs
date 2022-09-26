using System;

namespace EnglishNameOfTheLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string result = LastNumber(n);
            Console.WriteLine(result);
        }

        static string LastNumber(int number)
        {
            int input = number;

            switch (input % 10)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                    case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 0:
                    return "zero";

                default:
                    return "Invalid";
                    
            }

        }
    }
}
