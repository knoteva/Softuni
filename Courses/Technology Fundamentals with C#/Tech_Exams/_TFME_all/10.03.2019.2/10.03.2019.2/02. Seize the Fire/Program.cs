using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split("#")
               .Where(s => !string.IsNullOrWhiteSpace(s))
               .ToList();
            int water = int.Parse(Console.ReadLine());
            var result = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                string typeOfFire = input[i].Split(" = ")[0];
                int valueOfCell = int.Parse(input[i].Split(" = ")[1]);

                if (typeOfFire == "High" && valueOfCell >= 81 && valueOfCell <= 125 && water >= valueOfCell)
                {
                    water -= valueOfCell;
                    result.Add(valueOfCell);
                }
                else if (typeOfFire == "Medium" && valueOfCell >= 51 && valueOfCell <= 80 && water >= valueOfCell)
                {
                    water -= valueOfCell;
                    result.Add(valueOfCell);
                }
                else if (typeOfFire == "Low" && valueOfCell >= 1 && valueOfCell <= 50 && water >= valueOfCell)
                {
                    water -= valueOfCell;
                    result.Add(valueOfCell);
                }
            }
            Console.WriteLine("Cells:");
            foreach (var cell in result)
            {
                Console.WriteLine($" - {cell}");
            }
            Console.WriteLine($"Effort: {result.Sum(x => x * 0.25):F2}");
            Console.WriteLine($"Total Fire: {result.Sum(x => x)}");
        }
    }
}
