using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var dict = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "END")
            {
                string command = input.Split("->")[0];
                string store = input.Split("->")[1];

                if (command == "Add")
                {
                    string[] items = input.Split("->")[2].Split(",");

                    if (!dict.ContainsKey(store))
                    {
                        dict.Add(store, new List<string>());
                    }
                    foreach (var item in items)
                    {
                        dict[store].Add(item);
                    }
                }
                else
                {
                    if (dict.ContainsKey(store))
                    {
                        dict.Remove(store);
                    }
                }
                
            }
            Console.WriteLine($"Stores list:");
            foreach (var kvp in dict.OrderByDescending(x => x.Value.Count).ThenByDescending(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, $"<<{item}>>"));
                }
            }
        }
    }
}
