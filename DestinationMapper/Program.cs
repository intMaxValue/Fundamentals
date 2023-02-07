using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string locations = Console.ReadLine();
            string pattern = "(=|\\/)(?<location>[A-Z][A-Za-z]{2,})(\\1)";
            
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(locations);

            int travelPoints = 0;
            List<string> locationList = new List<string>();

            foreach (Match match in matches) 
            {
                travelPoints += match.Groups["location"].Value.Length;
                locationList.Add(match.Groups["location"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", locationList)}");
            
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
