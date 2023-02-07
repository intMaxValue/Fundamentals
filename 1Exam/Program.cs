using System;
using System.Linq;

namespace _1Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] cmnd = input.Split(" ");
                string action = cmnd[0];

                if (action == "Change")
                {
                    char character = char.Parse(cmnd[1]);
                    char replacement = char.Parse(cmnd[2]);

                    text = text.Replace(character, replacement);
                    Console.WriteLine(text);
                }
                else if (action == "Includes")
                {
                    string substring = cmnd[1];

                    if (text.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }

                }
                else if (action == "End")
                {
                    string substring = cmnd[1];
                    if (text.EndsWith(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (action == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (action == "FindIndex")
                {
                    char character = char.Parse(cmnd[1]);
                    int index = text.IndexOf(character);
                    Console.WriteLine(index);
                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(cmnd[1]);
                    int count = int.Parse(cmnd[2]);

                    string substring = text.Substring(startIndex, count);

                    //string secondCut = text.Remove(startIndex + count, text.Length - 1);
                    //string firstCut = text.Remove(0, startIndex);

                    Console.WriteLine(substring);
                }
            }
        }
    }
}
