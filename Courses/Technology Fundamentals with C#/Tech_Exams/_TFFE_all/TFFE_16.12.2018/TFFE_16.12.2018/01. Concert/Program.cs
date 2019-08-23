using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            var topBand = new Dictionary<string, List<string>>();
            var forTime = new Dictionary<string, int>();

            while ((line = Console.ReadLine()) != "start of concert")
            {
                var splitedLine = line.Split("; ");
                string command = splitedLine[0];
                string bandName = splitedLine[1];
                //splitedLine = splitedLine.Skip(2).ToArray();

                if (command == "Add")
                {

                    var members = splitedLine[2].Split(", ");
                    if (!topBand.ContainsKey(bandName))
                    {
                        topBand.Add(bandName, new List<string>());
                    }
                    foreach (var member in members)
                    {
                        if (!topBand[bandName].Contains(member))
                        {
                            topBand[bandName].Add(member);
                        }
                    }
                }
                else if (command == "Play")
                {
                    int time = int.Parse(splitedLine[2]);
                    if (!forTime.ContainsKey(bandName))
                    {
                        forTime.Add(bandName, 0);
                    }
                    forTime[bandName] += time; 
                }
            }

            string brandtoPrint = Console.ReadLine();

            Console.WriteLine($"Total time: {forTime.Values.Sum()}");
            foreach (var kvp in forTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            foreach (var kvp in topBand.Where(x => x.Key == brandtoPrint))
            {
                Console.WriteLine(kvp.Key);
                foreach (var n in kvp.Value)
                {
                    Console.WriteLine($"=> {n}");
                }
            }
        }
    }
}
