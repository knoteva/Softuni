using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chars = new List<string>();
            chars.Add(Console.ReadLine());
            chars.Add(Console.ReadLine());
            chars.Add(Console.ReadLine());
            chars.Reverse();
            string result = chars.Aggregate((a, b) => a + " " + b);
            Console.WriteLine(result);
        }
    }
}
