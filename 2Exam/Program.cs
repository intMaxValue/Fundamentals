using System;
using System.Text.RegularExpressions;

namespace _2Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string pattern = "\\|(?<name>[A-Z]{4,})\\|:#(?<title>[A-Za-z]+\\s?[A-Za-z]+)#";
                
                Regex regex= new Regex(pattern);
                Match match= regex.Match(input);
               
                if (match.Success)
                {
                    Console.WriteLine($"{match.Groups["name"].Value}, The {match.Groups["title"].Value}");
                    Console.WriteLine($">> Strength: {match.Groups["name"].Value.Length}");
                    Console.WriteLine($">> Armor: {match.Groups["title"].Value.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
