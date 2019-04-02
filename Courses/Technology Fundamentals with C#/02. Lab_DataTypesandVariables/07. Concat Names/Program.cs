using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>();
            names.Add(Console.ReadLine());
            names.Add(Console.ReadLine());
            string result = names.Aggregate((a, b) => a + Console.ReadLine() + b);
            Console.WriteLine(result);
        }
    }
}
