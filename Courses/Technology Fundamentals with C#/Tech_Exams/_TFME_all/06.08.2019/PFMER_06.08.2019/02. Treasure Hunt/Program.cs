using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
               .Split('|')
               .Where(x => !string.IsNullOrWhiteSpace(x))
               .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                string command = input.Split(" ")[0];

                if (command == "Loot")
                {
                    var items = input.Split(" ").Skip(1).ToArray();
                    foreach (var item in items)
                    {
                        if (!list.Contains(item))
                        {
                            list.Insert(0, item);
                        }
                    }

                }
                else if (command == "Drop")
                {
                    int index = int.Parse(input.Split(" ")[1]);

                    if (index >= 0 && index < list.Count)
                    {
                        var item = list[index];
                        list.RemoveAt(index);
                        list.Add(item);
                    }
                }
                else if (command == "Steal")
                {
                    int count = int.Parse(input.Split(" ")[1]);
                    if (count > list.Count)
                    {
                        count = list.Count;
                    }
                    list.Reverse();
                    var steal = new List<string>();
                    for (int i = 0; i < count; i++)
                    {
                        steal.Add(list[0]);
                        list.RemoveAt(0);
                    }
                    list.Reverse();
                    steal.Reverse();
                    Console.WriteLine(string.Join(", ", steal));
                }
            }

            if (list.Count == 0)
            {
                Console.WriteLine($"Failed treasure hunt.");
            }
            else
            {
                int length = 0;
                foreach (var item in list)
                {
                    length += item.Length;
                }
                double averageGain = length / (double)list.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
            }
        }
    }
}
