using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = "((\\#|\\|){1})(?<food>[A-Za-z\\s]+)(\\1)(?<expire>[0-9]{2}\\/[0-9]{2}\\/[0-9]{2})(\\1)(?<calories>[0-9]+)(\\1)";

            int totalCalories = 0;

            List<Food> food = new List<Food>();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                string item = match.Groups["food"].Value;
                string expireDate = match.Groups["expire"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                Food currItem = new Food(item, expireDate, calories);
                food.Add(currItem);
                totalCalories += calories;
            }

            int days = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            if (days > 0)
            {
                foreach (var item in food)
                {
                    Console.WriteLine($"Item: {item.Name}, Best before: {item.ExpireDate}, Nutrition: {item.Calories}");

                }
            }
        }

    }

    public class Food
    {
        public Food(string name, string expireDate, int calories)
        {
            Name = name;
            ExpireDate = expireDate;
            Calories = calories;
        }
        public string Name { get; set; }
        public string ExpireDate { get; set; }
        public int Calories { get; set; }
    }
}
