using System;
using System.Linq;

namespace _02._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split("|")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
            int energy = 100;
            int coins = 0;
            for (int i = 0; i < list.Count; i++)
            {
                string command = list[i].Split(" ")[0];
                int item = int.Parse(list[i].Split(" ")[1]);

                if (command == "potion")
                {
                    if (energy + item > 100)
                    {
                        item = 100 - energy;
                        energy = 100;
                    }
                    else
                    {
                        energy += item;
                    }
                    Console.WriteLine($"You healed for {item} hp.");
                    Console.WriteLine($"Current health: {energy} hp.");
                }
                else if (command == "chest")
                {
                    coins += item;
                    Console.WriteLine($"You found {item} coins.");
                }
                else
                {
                    energy -= item;
                    if (energy > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: { energy}");
        }
    }
}
