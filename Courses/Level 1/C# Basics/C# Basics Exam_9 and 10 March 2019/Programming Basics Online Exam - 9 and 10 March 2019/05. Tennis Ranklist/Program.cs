using System;

namespace _05._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            int points = startPoints;
            double count = 0;

            for (int i = 0; i < num; i++)
            {
                string tour = Console.ReadLine();
                if (tour == "W")
                {
                    points += 2000;
                    count++;
                }
                if (tour == "F")
                {
                    points += 1200;
                }
                if (tour == "SF")
                {
                    points += 720;
                }
            }
            Console.WriteLine($"Final points: {points}");
            double avg = (points - startPoints) / num;
            Console.WriteLine($"Average points: {Math.Floor(avg)}");
            double wins = count / num * 100;
            Console.WriteLine($"{wins:F2}%");
        }
    }
}
