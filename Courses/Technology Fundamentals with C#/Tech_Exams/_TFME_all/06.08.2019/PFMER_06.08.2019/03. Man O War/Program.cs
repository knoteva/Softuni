using System;
using System.Linq;

namespace _03._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            var pirateShip = Console.ReadLine()
                .Split('>')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(int.Parse)
                .ToList();
            var warShip = Console.ReadLine()
                .Split('>')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(int.Parse)
                .ToList();
            int maxHealth = int.Parse(Console.ReadLine());

            string input;

            while ((input = Console.ReadLine()) != "Retire")
            {
                string command = input.Split(" ")[0];

                if (command == "Fire")
                {
                    int index = int.Parse(input.Split(" ")[1]);
                    int damage = int.Parse(input.Split(" ")[2]);

                    if (index >= 0 && index <= warShip.Count)
                    {
                        warShip[index] -= damage;
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine($"You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (command == "Defend")
                {
                    int startIndex = int.Parse(input.Split(" ")[1]);
                    int endIndex = int.Parse(input.Split(" ")[2]);
                    int damage = int.Parse(input.Split(" ")[3]);
                    if (startIndex >= 0 && startIndex <= pirateShip.Count - 1 && endIndex >= 0 && endIndex <= pirateShip.Count - 1 && startIndex <= endIndex)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine($"You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (command == "Repair")
                {
                    int index = int.Parse(input.Split(" ")[1]);
                    int health = int.Parse(input.Split(" ")[2]);

                    if (index >= 0 && index <= pirateShip.Count - 1)
                    {
                        pirateShip[index] += health;
                        if (pirateShip[index] > maxHealth)
                        {
                            pirateShip[index] = maxHealth;
                        }
                    }
                }
                else if (command == "Status")
                {
                    int sections = 0;
                    foreach (var item in pirateShip)
                    {
                        if (item / (double)maxHealth < 0.2)
                        {
                            sections++;
                        }

                    }
                    Console.WriteLine($"{sections} sections need repair.");
                }
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");


        }
    }
}
