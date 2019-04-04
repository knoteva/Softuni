using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int first = int.Parse(Console.ReadLine());
            //int second = int.Parse(Console.ReadLine());
            //int third = int.Parse(Console.ReadLine());
            var numbers = new List<int> { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) };

            SmallestNumber(numbers);
        }

        private static void SmallestNumber(List<int> numbers)
        {
            Console.WriteLine(numbers.Min());
        }
    }
}
