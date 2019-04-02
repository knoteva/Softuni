using System;
using System.Diagnostics;

namespace _01._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double meters = double.Parse(Console.ReadLine());

            //Stopwatch sw = Stopwatch.StartNew();
            double km = meters / 1000;
           // Console.WriteLine(sw.Elapsed);
            Console.WriteLine($"{km:F2}");
            //Console.WriteLine(sw.Elapsed);
        }
    }
}
