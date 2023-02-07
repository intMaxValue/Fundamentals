using System;

namespace ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] cmnd = input.Split(">>>");
                string action = cmnd[0];

                switch (action)
                {
                    case "Contains":
                        Contains(key, cmnd[1]);
                        break;
                    case "Flip":
                        key = Flip(key, cmnd[1], int.Parse(cmnd[2]), int.Parse(cmnd[3]));
                        break;
                    case "Slice":
                        key = Slice(key, int.Parse(cmnd[1]), int.Parse(cmnd[2]));
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {key}");
        }

        private static string Slice(string key, int startIndex, int endIndex)
        {
            key = key.Remove(startIndex, endIndex - startIndex);
            Console.WriteLine(key);
            return key;
        }

        private static string Flip(string key, string upperOrLower, int startIndex, int endIndex)
        {
            string substring = key.Substring(startIndex, endIndex - startIndex);
            
            key = key.Remove(startIndex, substring.Length);
           
            if (upperOrLower == "Upper")
            {
                
                key = key.Insert(startIndex, substring.ToUpper());
            }
            else if (upperOrLower == "Lower")
            {
                key = key.Insert(startIndex, substring.ToLower());
            }

            Console.WriteLine(key);
            return key;
        }

        private static void Contains(string key, string substring)
        {
            if (key.Contains(substring))
            {
                Console.WriteLine($"{key} contains {substring}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }
    }
}
