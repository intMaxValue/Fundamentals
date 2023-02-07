using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = "(@|#)(?<first>[A-Za-z]{3,})(\\1)(\\1)(?<second>[A-Za-z]{3,})(\\1)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            List<string> mirrorWords = new List<string>();

            foreach (Match item in matches)
            {
                string firstWord = item.Groups["first"].Value;
                string secondWord = item.Groups["second"].Value;

                string secondWordReversed = string.Join("", secondWord.Reverse());

                if (firstWord == secondWordReversed)
                {
                    mirrorWords.Add($"{firstWord} <=> {secondWord}");
                }
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }

        }
    }
}
