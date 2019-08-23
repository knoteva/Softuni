using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = Console.ReadLine()
                .Split(' ')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();
            var print = new List<string>();

            string input;

            while (!(input = Console.ReadLine()).Contains("Print"))
            {
                string command = input.Split(" ")[0];

                if (command == "Join")
                {
                    string name = input.Split(" ")[1];
                 
                    if (!list.Contains(name))
                    {
                        list.Add(name);
                    }
                }
                else if (command == "Jump")
                {
                    string name = input.Split(" ")[1];
                    int index = int.Parse(input.Split(" ")[2]);

                    if (index >= 0 && index < list.Count)
                    {
                        list.Insert(index, name);
                    }
                }
                else if (command == "Dive")
                {
                    int index = int.Parse(input.Split(" ")[1]);

                    if (index >= 0 && index < list.Count)
                    {
                        list.RemoveAt(index);
                    }
                }
                else if (command == "First")
                {
                    int count = int.Parse(input.Split(" ")[1]);

                        if (count >= list.Count)
                        {
                            count = list.Count;
                        }
                        print = list.Take(count).Select(x => x).ToList();
                        //print.Reverse();
                        Console.WriteLine(string.Join(" ", print));
                }
                else if (command == "Last")
                {
                    int count = int.Parse(input.Split(" ")[1]);

                    if (count >= list.Count)
                    {
                        count = list.Count;
                    }
                    list.Reverse();
                    print = list.Take(count).Select(x => x).ToList();
                    print.Reverse();
                    list.Reverse();
                    Console.WriteLine(string.Join(" ", print));
                }

            }
            if (input.Split(" ")[1] == "Reversed")
            {
                list.Reverse();
            }
            Console.WriteLine($"Frogs: {string.Join(" ", list)}");
        }
    }
}
