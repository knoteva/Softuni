using System;
using System.Numerics;

namespace Sino_The_Wolker
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputtime = Console.ReadLine();
            int steps = int.Parse(Console.ReadLine()) % 86400;
            int timeofonestepinseconds = int.Parse(Console.ReadLine()) % 86400;
            int timeadd = steps * timeofonestepinseconds;

            DateTime arrival = DateTime.ParseExact(inputtime, "HH:mm:ss", null);
            string result = arrival.AddSeconds(timeadd).ToString("HH:mm:ss");
            Console.WriteLine($"Time Arrival: {result}");
        }
    }
}

