using System;
using System.Threading;

namespace MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;

            string[] rooms = Console.ReadLine().Split("|");

            for (int i = 1; i <= rooms.Length ; i++)
            {
                string[] room = rooms[i - 1].Split(" ");

                if (room[0] == "potion")
                {
                    int healing = int.Parse(room[1]);
                    if (health + healing > 100)
                    {
                        healing = 100 - health;
                        health = 100;
                    }
                    else
                    {
                        health += healing;
                    }

                    Console.WriteLine($"You healed for {healing} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (room[0] == "chest")
                {
                    int bitcoinsFound = int.Parse(room[1]);

                    Console.WriteLine($"You found {bitcoinsFound} bitcoins.");
                    bitcoins += bitcoinsFound;
                }
                else
                {
                    int monsterAttack = int.Parse(room[1]);

                    health -= monsterAttack;

                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {room[0]}.");
                        Console.WriteLine($"Best room: {i}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {room[0]}.");
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
