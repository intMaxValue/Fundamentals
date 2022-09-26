using System;
using System.Linq;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;
            int attemptCount = 1;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != password)
            {
                if (attemptCount == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }


                Console.WriteLine("Incorrect password. Try again.");
                attemptCount++;
                
            }

            if (input == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
