using System;
using System.Linq;

namespace _03._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var houses = Console.ReadLine()
                .Split('@')
                .Select(int.Parse)
                .ToList();
            string input;
            int currentPosition = 0;
            while ((input = Console.ReadLine()) != "Merry Xmas!")
            {
                int jump = int.Parse(input.Split(" ")[1]);
                currentPosition = (currentPosition + jump) % houses.Count;

                if (houses[currentPosition] != 0)
                {
                    houses[currentPosition] -= 2;
                }
                else
                {
                    Console.WriteLine($"House {currentPosition} will have a Merry Christmas.");
                }
            }
            Console.WriteLine($"Santa's last position was {currentPosition}.");

            houses.RemoveAll(item => item == 0);

            if (houses.Count == 0)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {houses.Count} houses.");
            }
        }
    }
}
