using System;

namespace _06._Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";          
            double wins = 0;
            double loose = 0;


            while ((command = Console.ReadLine()) != "End of tournaments")
            {
                string tournir = command;
                int num = int.Parse(Console.ReadLine());
                for (int i = 1; i <= num; i++)
                {
                    int points1 = int.Parse(Console.ReadLine());
                    int points2 = int.Parse(Console.ReadLine());
                    if (points1 > points2)
                    {
                        Console.WriteLine($"Game {i} of tournament {tournir}: win with {points1 - points2} points.");
                        wins++;
                    }
                    else
                    {
                        Console.WriteLine($"Game {i} of tournament {tournir}: lost with {points2 - points1} points.");
                        loose++;
                    }
                }
            }
            double matches = wins + loose;
            Console.WriteLine($"{(wins / matches * 100):F2}% matches win");
            Console.WriteLine($"{(loose / matches * 100):F2}% matches lost");
        }
    }
}
