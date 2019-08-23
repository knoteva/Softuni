using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var dict = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "END")
            {
                string command = input.Split("->")[0];
                string road = input.Split("->")[1];

                if (command == "Add")
                {
                    string racer = input.Split("->")[2];
                    if (!dict.ContainsKey(road))
                    {
                        dict.Add(road, new List<string>());
                    }
                    dict[road].Add(racer);
                }
                else if (command == "Move")
                {
                    string racer = input.Split("->")[2];
                    string nextRoad = input.Split("->")[3];
                    if (dict[road].Contains(racer))
                    {
                        dict[road].Remove(racer);
                        dict[nextRoad].Add(racer);
                    }
                }
                else if (command == "Close")
                {
                    if (dict.ContainsKey(road))
                    {
                        dict.Remove(road);
                    }
                }
            }

            Console.WriteLine("Practice sessions:");
            Console.WriteLine($"{string.Join(Environment.NewLine, dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).Select(x => $"{x.Key}{Environment.NewLine}{string.Join(Environment.NewLine, x.Value.Select(y => $"++{y}"))}"))}");
        }
    }
}
