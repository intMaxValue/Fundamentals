using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var log = new SortedDictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] received = input.Split(new string[] { "IP=", " ", "user=" }, StringSplitOptions.RemoveEmptyEntries);
                string ip = received[0];
                string user = received[2];

                if (!log.ContainsKey(user))
                {
                    log.Add(user, new Dictionary<string, int>());
                    log[user] = new Dictionary<string, int>();
                    log[user].Add(ip, 1);
                }
                else if (log.ContainsKey(user) && !log[user].ContainsKey(ip))
                {
                    log[user][ip] = 1;

                }
                else if (log.ContainsKey(user) && log[user].ContainsKey(ip))
                {
                    log[user][ip] += 1;

                }
            }


            foreach (var user in log)
            {
                List<string> list = new List<string>();
                
                Console.WriteLine($"{user.Key}:");
                
                foreach (var item in user.Value)
                {
                    string output = $"{item.Key}" + " => " + $"{item.Value}";
                    list.Add(output);

                }
                Console.Write(string.Join(", ", list) + ".");
                Console.WriteLine();
            }
        }
    }


}
