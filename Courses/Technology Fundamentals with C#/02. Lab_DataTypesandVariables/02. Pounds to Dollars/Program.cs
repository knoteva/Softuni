using System;
using System.Diagnostics;

namespace _01._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {

            double pounds = double.Parse(Console.ReadLine());
            double us = pounds * 1.31;
            Console.WriteLine($"{us:F3}");
        }
    }
}