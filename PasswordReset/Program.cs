using System;

namespace PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] cmnd = input.Split(' ');
                string action = cmnd[0];

                if (action == "TakeOdd")
                {
                    string takeOdd = string.Empty;

                    for (int i = 1; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            takeOdd += password[i].ToString();
                        }
                    }
                    password = takeOdd;
                    Console.WriteLine(password);
                }

                else if (action == "Cut")
                {
                    int index = int.Parse(cmnd[1]);
                    int length = int.Parse(cmnd[2]);

                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }

                if (action == "Substitute")
                {
                    string substring = cmnd[1];
                    string substitute = cmnd[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
