using System;

namespace _02._Football_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            int won = 0;
            int lost = 0;
            int drawn = 0;          
            for (int i = 0; i < 3; i++)
            {
                string str = Console.ReadLine();
                int left = int.Parse(str.Split(':')[0]);
                int right = int.Parse(str.Split(':')[1]);
                if (left > right)
                {
                    won++;
                }
                else if (right > left)
                {
                    lost++;
                }
                else
                {
                    drawn++;
                }
            }
            Console.WriteLine($"Team won {won} games.\nTeam lost {lost} games.\nDrawn games: {drawn}");
        }
    }
}
