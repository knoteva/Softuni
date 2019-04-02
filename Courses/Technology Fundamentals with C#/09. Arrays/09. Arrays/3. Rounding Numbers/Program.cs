using System;
using System.Linq;

namespace _3._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            foreach (double value in nums)
            {
                Console.WriteLine($"{value} => {(int)Math.Round(value, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
