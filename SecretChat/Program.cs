using System;
using System.Linq;

namespace SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] cmnd = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string action = cmnd[0];

                if (action == "InsertSpace")
                {
                    int index = int.Parse(cmnd[1]);
                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }

                else if (action == "Reverse")
                {
                    string substring = cmnd[1];

                    if (message.Contains(substring))
                    {
                        string reversedSubstring = string.Join("", substring.Reverse());
                        int indexOfSubstring = message.IndexOf(substring);
                       
                        message = message.Remove(indexOfSubstring, substring.Length);
                        message += reversedSubstring;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    Console.WriteLine(message);
                }

                else if (action == "ChangeAll")
                {
                    string substring = cmnd[1];
                    string replacement = cmnd[2];

                    message = message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }

            }

            Console.WriteLine($"You have a new text message: {message}");

        }
    }
}
