using System;

namespace _01._Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double floorPricePerKg = double.Parse(Console.ReadLine());
            double eggsPricePerPack = 0.75 * floorPricePerKg;
            double milk = 1.25 * floorPricePerKg / 4;
            double kozunakPrice = floorPricePerKg + eggsPricePerPack + milk; 
            int coloredEggs = 0;
            int countOfCozonacs = 0;

            while (budget - kozunakPrice > 0)
            {
                budget -= kozunakPrice;
                countOfCozonacs++;
                coloredEggs += 3;
                if (countOfCozonacs % 3 == 0)
                {
                    coloredEggs -= countOfCozonacs - 2;
                }
            }


            Console.WriteLine($"You made {countOfCozonacs} cozonacs! Now you have {coloredEggs} eggs and {budget:F2}BGN left.");
        }
    }
}
