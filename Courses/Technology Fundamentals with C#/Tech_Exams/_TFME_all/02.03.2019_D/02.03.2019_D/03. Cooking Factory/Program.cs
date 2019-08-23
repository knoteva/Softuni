using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cooking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split("#")
               .Where(s => !string.IsNullOrWhiteSpace(s))
               .ToList();

            var bestBatch = new List<int>();
            var bestQuality = 0;
            var bestAvg = 0.00;
            var bestLength = 0;

            while (true)
            {
                if (input.Contains("Bake It!"))
                {
                    break;
                }
                int currQuality = input.Sum(x => int.Parse(x));
                double currAvg = input.Average(x => int.Parse(x));
                int currlength = input.Count;
                if (bestQuality < currQuality)
                {
                    bestQuality = currQuality;
                    bestBatch = input.Select(int.Parse).ToList();
                    bestAvg = currAvg;
                    bestLength = currlength;
                }
                else if (bestQuality == currQuality)
                {
                    if (bestAvg < currAvg)
                    {
                        //bestQuality = currQuality;
                        bestBatch = input.Select(int.Parse).ToList();
                        bestAvg = currAvg;
                        bestLength = currlength;
                    }
                    else if (bestAvg == currAvg)
                    {
                        if (bestLength < currlength)
                        {
                            bestQuality = currQuality;
                            bestBatch = input.Select(int.Parse).ToList();
                        }
                    }
                }
                input = Console.ReadLine()
               .Split("#")
               .Where(s => !string.IsNullOrWhiteSpace(s))
               .ToList();
            }

            Console.WriteLine($"Best Batch quality: {bestQuality}");
            Console.WriteLine($"{string.Join(" ", bestBatch)}");
        }
    }
}
