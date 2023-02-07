using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> list = new Dictionary<string, string>();
           
            Dictionary<string, List<double>> rating = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] startingPlants = Console.ReadLine().Split("<->");
                string plant = startingPlants[0];
                string rarity = startingPlants[1];

                list.Add(plant, rarity);
                rating.Add(plant, new List<double>());
            }

            string input;


            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] cmnd = input.Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
                string command = cmnd[0];
                string plant = cmnd[1];

                if (command == "Rate" && rating.Keys.Contains(plant))
                {
                    double currRating = double.Parse(cmnd[2]);

                    rating[plant].Add(currRating);

                }
                else if (command == "Update" && list.Keys.Contains(plant))
                {
                    string newRarity = cmnd[2];
                    list[plant] = newRarity; 
                }
                else if (command == "Reset" && list.Keys.Contains(plant))
                {
                    rating[plant].Clear();
                    
                }
                else 
                {
                    Console.WriteLine("error");
                }
                
            }

            Console.WriteLine("Plants for the exhibition:");
            
            var average = new Dictionary<string, double>();

            foreach (var item in rating)
            {
                double averageRating = 0;
                
                double sum = item.Value.Sum();
                
                if (item.Value.Count > 0)
                {
                    averageRating = sum / item.Value.Count;
                }
                else
                {
                    averageRating= 0.00;
                }

                average.Add(item.Key, averageRating);
            }

            foreach (var plant in list)
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value}; Rating: {average[plant.Key]:F2}");
            }
        }
    }
}
