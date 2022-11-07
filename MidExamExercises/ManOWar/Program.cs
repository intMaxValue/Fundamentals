using System;
using System.Linq;

namespace ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
            int[] battleShip = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
            int maximumHealth = int.Parse(Console.ReadLine());

            string input = "";

            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] command = input.Split(' ');

                if (command[0] == "Fire")
                {
                    if (int.Parse(command[1]) > battleShip.Length - 1
                        || int.Parse(command[1]) < 0)
                    {
                        continue;
                    }

                    int index = int.Parse(command[1]);
                    int damage = int.Parse(command[2]);

                    battleShip[index] -= damage;
                    if (battleShip[index] <= 0)
                    {
                        Console.WriteLine($"You won! The enemy ship has sunken.");
                        return;
                    }
                }
                else if (command[0] == "Defend")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    int damage = int.Parse(command[3]);

                    if (startIndex < 0 || endIndex > pirateShip.Length - 1)
                    {
                        continue;
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        pirateShip[i] -= damage;

                        if (pirateShip[i] <= 0)
                        {
                            Console.WriteLine("You lost! The pirate ship has sunken.");
                            return;
                        }
                    }
                }
                else if (command[0] == "Repair")
                {
                    int index = int.Parse(command[1]);
                    int health = int.Parse(command[2]);

                    if (index < 0 || index > pirateShip.Length - 1)
                    {
                        continue;
                    }

                    if (pirateShip[index] + health > maximumHealth)
                    {
                        pirateShip[index] = maximumHealth;
                    }
                    else
                    {
                        pirateShip[index] += health;
                    }
                }
                else if (command[0] == "Status")
                {
                    double needsRepair = maximumHealth * 0.2;
                    int sections = 0;

                    for (int i = 0; i < pirateShip.Length; i++)
                    {
                        if (pirateShip[i] < needsRepair)
                        {
                            sections++;
                        }
                    }

                    Console.WriteLine($"{sections} sections need repair.");
                }

            }

            if (battleShip.Sum() > 0 && pirateShip.Sum() > 0)
            {
                Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
                Console.WriteLine($"Warship status: {battleShip.Sum()}");

            }
        }
    }
}
