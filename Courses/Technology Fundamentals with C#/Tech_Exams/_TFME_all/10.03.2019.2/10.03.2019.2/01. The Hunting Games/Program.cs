using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine()) * days * players;
            double food = double.Parse(Console.ReadLine()) * days * players;

            for (int i = 1; i <= days; i++)
            {
                double lostEnergy = double.Parse(Console.ReadLine());

                if (energy > lostEnergy)
                {
                    energy -= lostEnergy;
                    if (i % 2 == 0)
                    {
                        water *= 0.7;
                        energy *= 1.05;
                    }
                    if (i % 3 == 0)
                    {
                        food -= food / players;
                        energy *= 1.10;
                    }
                }
                
                else
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {food:F2} food and {water:F2} water.");
                    return;
                }
            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {energy:F2} energy!");
        }
    }
}
