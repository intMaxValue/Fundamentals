using System;

namespace TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string input;

            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] cmnd = input.Split("|");

                string action = cmnd[0];

                if (action == "Move")
                {
                    int numberOfLetters = int.Parse(cmnd[1]);
                    string lettersToMove = encryptedMessage.Substring(0, numberOfLetters);
                    
                    encryptedMessage = encryptedMessage.Remove(0, numberOfLetters);
                    encryptedMessage += lettersToMove; 
                }

                else if (action == "Insert")
                {
                    int index = int.Parse(cmnd[1]);
                    string value = cmnd[2];

                    encryptedMessage = encryptedMessage.Insert(index, value);
                }

                else if (action == "ChangeAll")
                {
                    string substring = cmnd[1];
                    string replacement = cmnd[2];

                    encryptedMessage = encryptedMessage.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
