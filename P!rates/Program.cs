using System;
using System.Collections.Generic;
using System.Drawing;

namespace P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, City>();

            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] inpt = input.Split("||");

                string city = inpt[0];
                int population = int.Parse(inpt[1]);
                int gold = int.Parse(inpt[2]);

                if (!cities.ContainsKey(city))
                {
                    cities[city] = new City(population, gold);
                }
                else
                {
                    cities[city].Population += population;
                    cities[city].Gold += gold;
                }
            }

            string events;
            while ((events = Console.ReadLine()) != "End")
            {
                string[] cmnd = events.Split("=>");
                string action = cmnd[0];
                string city = cmnd[1];

                if (action == "Plunder")
                {
                    int population = int.Parse(cmnd[2]);
                    int gold = int.Parse(cmnd[3]);

                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {population} citizens killed.");
                    cities[city].Population -= population;
                    cities[city].Gold -= gold;

                    if (cities[city].Population <= 0 || cities[city].Gold <= 0)
                    {
                        Console.WriteLine($"{city} has been wiped off the map!");

                        cities.Remove(city);
                    }
                }

                else if (action == "Prosper")
                {
                    int gold = int.Parse(cmnd[2]);

                    if (gold <= 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[city].Gold += gold;

                        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city].Gold} gold.");
                    }
                }
            }
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }

    public class City
    {
        public City(int population, int gold)
        {
            Population = population;
            Gold = gold;
        }

        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
