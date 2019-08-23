using System;
using System.Linq;

namespace _02._Bread_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split("|")
               .Where(s => !string.IsNullOrWhiteSpace(s))
               .ToList();
            int energy = 100;
            int coins = 100;

            for (int i = 0; i < input.Count; i++)
            {
                string item = input[i].Split("-")[0];
                int number = int.Parse(input[i].Split("-")[1]);

                if (item == "rest")
                {
                    if (energy + number > 100)
                    {
                        number = 100 - energy;
                        energy = 100;
                    }
                    else
                    {
                        energy += number;
                    }
                    Console.WriteLine($"You gained {number} energy.");
                    Console.WriteLine($"Current energy: {energy}.");
                }
                else if (item == "order")
                {
                    if (energy >= 30)
                    {
                        energy -= 30;
                        coins += number;
                        Console.WriteLine($"You earned {number} coins.");
                    }
                    else
                    {
                        energy += 50;
                        Console.WriteLine($"You had to rest!");
                    }
                }
                else
                {
                    if (coins > number)
                    {
                        coins -= number;
                        Console.WriteLine($"You bought {item}.");
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {item}.");
                        return;
                    }
                }
            }
            Console.WriteLine($"Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {energy}");            
        }
    }
}
