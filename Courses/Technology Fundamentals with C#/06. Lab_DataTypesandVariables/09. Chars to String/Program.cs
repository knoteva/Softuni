using System;
using System.Collections.Generic;

namespace _09._Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var chars = new List<string>();
            chars.Add(Console.ReadLine());
            chars.Add(Console.ReadLine());
            chars.Add(Console.ReadLine());
            chars.ForEach(Console.Write);
            //Console.WriteLine();
        }
    }
}
