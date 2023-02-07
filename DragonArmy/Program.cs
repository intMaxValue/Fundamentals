using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace DragonArmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dragons = new Dictionary<string, Dictionary<string, List<double>>>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = input[0];
                string name = input[1];
                double damage = input[2] == "null" ? 45 : double.Parse(input[2]);
                double health = input[3] == "null" ? 250 : double.Parse(input[3]);
                double armor = input[4] == "null" ? 10 : double.Parse(input[4]);

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new Dictionary<string, List<double>>());
                }

                dragons[type][name] = new List<double>();

                dragons[type][name].Add(damage);
                dragons[type][name].Add(health);
                dragons[type][name].Add(armor);

            }

            foreach (var type in dragons)
            {
                double avrDamage = type.Value.Values.Select(x => x[0]).Sum() / dragons[type.Key].Count;
                double avrHealth = type.Value.Values.Select(x => x[1]).Sum() / dragons[type.Key].Count;
                double avrArmor = type.Value.Values.Select(x => x[2]).Sum() / dragons[type.Key].Count;

                Console.WriteLine($"{type.Key}::({avrDamage:f2}/{avrHealth:f2}/{avrArmor:f2})");
                
                foreach (var dragon in type.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }



            }

        }
    }


}
