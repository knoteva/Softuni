using System;

namespace _06._Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int kozunaci = int.Parse(Console.ReadLine());
            int maxPoints = 0;
            string winner = string.Empty;

            for (int i = 0; i < kozunaci; i++)
            {
                string chef = Console.ReadLine();
                int points = 0;

                string line;
                while ((line = Console.ReadLine()) != "Stop")
                {
                    points += int.Parse(line);
                }
                Console.WriteLine($"{chef} has {points} points.");
                if (points > maxPoints)
                {
                    maxPoints = points;
                    winner = chef;
                    Console.WriteLine($"{winner} is the new number 1!");
                }
            }
            Console.WriteLine($"{winner} won competition with {maxPoints} points!");
        }
    }
}
