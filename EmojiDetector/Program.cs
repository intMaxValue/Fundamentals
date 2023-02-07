using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            string emojiPattern = "(::|\\*\\*)(?<name>[A-Z][a-z]{2,})(\\1)";
            string numPattern = "\\d";

            Regex name = new Regex(emojiPattern);
            Regex nums = new Regex(numPattern);

            long coolThreshold = 1;

            MatchCollection coolnes = nums.Matches(input);

            foreach (Match num in coolnes)
            {
                coolThreshold *= long.Parse(num.ToString());
            }

            MatchCollection emojis = name.Matches(input);

            int emojiCount = emojis.Count;

            List<string> emojiList = new List<string>();

            foreach (Match emoji in emojis)
            {
                int emojiCoolnes = 0;
                foreach (char character in emoji.ToString())
                {
                    if (character == ':' || character == '*')
                    {
                        continue;
                    }
                    emojiCoolnes += character;
                }

                if (emojiCoolnes >= coolThreshold)
                {
                    emojiList.Add(emoji.ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiCount} emojis found in the text. The cool ones are:");

            foreach (var item in emojiList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
