using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = "@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);
                if (match.Success) 
                {
                    string productGroup = string.Empty;
                    string currMatch = match.Groups["barcode"].Value;

                    foreach (char item in currMatch)
                    {
                        if (char.IsDigit(item))
                        {
                            productGroup += item.ToString();
                        }
                    }

                    if (productGroup.Length == 0)
                    {
                        productGroup = "00";
                    }
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else 
                {
                    Console.WriteLine("Invalid barcode");
                }
            }

        }
    }
}
