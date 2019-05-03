using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());
            int redEggs = 0;
            int orangeEggs = 0;
            int blueEggs = 0;
            int greenEggs = 0;

            for (int i = 0; i < eggs; i++)
            {
                string color = Console.ReadLine();

                switch (color)
                {
                    case "red":
                        redEggs++;
                        break;
                    case "orange":
                        orangeEggs++;
                        break;
                    case "blue":
                        blueEggs++;
                        break;
                    case "green":
                        greenEggs++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Red eggs: {redEggs}");
            Console.WriteLine($"Orange eggs: {orangeEggs}");
            Console.WriteLine($"Blue eggs: {blueEggs}");
            Console.WriteLine($"Green eggs: {greenEggs}");

            var maxNumber = new Dictionary<string, int>
        {
            { "red", redEggs },
            { "orange", orangeEggs },
            { "blue", blueEggs },
            { "green", greenEggs }
        };
            var col = maxNumber.FirstOrDefault(x => x.Value == maxNumber.Values.Max()).Key;
            var quantity = maxNumber.FirstOrDefault(x => x.Value == maxNumber.Values.Max()).Value;
            Console.WriteLine($"Max eggs: {quantity} -> {col}");
        }
    }
}
