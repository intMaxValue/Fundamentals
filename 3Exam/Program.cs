using System;
using System.Collections.Generic;

namespace _3Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var heroes = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmnd = input.Split(" ");
                
                string action = cmnd[0];
                string heroName = cmnd[1];

                if (action == "Enroll")
                {
                    if (!heroes.ContainsKey(heroName))
                    {
                        heroes[heroName] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (action == "Learn")
                {
                    string spell = cmnd[2];
                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (heroes[heroName].Contains(spell))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spell}.");
                    }
                    else
                    {
                        heroes[heroName].Add(spell);
                    }

                }
                else if (action == "Unlearn")
                {
                    string spell = cmnd[2];

                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (!heroes[heroName].Contains(spell))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spell}");
                    }
                    else
                    {
                        heroes[heroName].Remove(spell);
                    }
                }

            }

            Console.WriteLine("Heroes:");

            foreach (var hero in heroes)
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
            }

        }
    }
}
