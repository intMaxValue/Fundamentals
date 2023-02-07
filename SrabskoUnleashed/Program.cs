using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SrabskoUnleashed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var unleashed = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string pattern = "^(?<name>[A-Z][A-Za-z\\s]+)\\s@(?<city>[A-Z][A-Za-z\\s]+)\\s(?<ticket>[0-9]+)\\s(?<people>[0-9]+)$";

                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string singer = match.Groups["name"].Value;
                    string city = match.Groups["city"].Value;
                    int ticket = int.Parse(match.Groups["ticket"].Value);
                    int people = int.Parse(match.Groups["people"].Value);

                    int totalMoney = ticket * people;

                    if (!unleashed.ContainsKey(city))
                    {
                        unleashed.Add(city, new Dictionary<string, int>());
                        unleashed[city].Add(singer, totalMoney);
                    }
                    else if (unleashed.ContainsKey(city))
                    {
                        if (unleashed[city].ContainsKey(singer))
                        {
                            unleashed[city][singer] += totalMoney;
                        }
                        else
                        {
                            unleashed[city].Add(singer, totalMoney);
                        }
                    }
                }
            }

            foreach (var kvp in unleashed)
            {
                Console.WriteLine(kvp.Key);

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }

            }
        }
    }
}
