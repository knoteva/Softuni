using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            double totalWater = days * playersCount * water;
            double totalFood = days * playersCount * food;
            double energyLoose = 0;
            //Console.WriteLine(totalFood);
           // Console.WriteLine(totalWater);
            for (int i = 1; i <= days; i++)
            {              
                energyLoose = double.Parse(Console.ReadLine());
                groupEnergy -= energyLoose;
                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
                    return;
                }
                if (i % 2 == 0)
                {
                    groupEnergy *= 1.05;
                    totalWater *= 0.7;
                }
                if (i % 3 == 0)
                {
                    groupEnergy *= 1.10;
                    totalFood -= totalFood / playersCount;
                }               
            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:F2} energy!");
        }
    }
}
