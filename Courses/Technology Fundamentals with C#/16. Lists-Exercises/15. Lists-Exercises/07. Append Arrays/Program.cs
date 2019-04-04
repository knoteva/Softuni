using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine()
              .Split('|').Where(s => !string.IsNullOrWhiteSpace(s))
              .Reverse()
              .ToList();

            for (int i = 0; i < arrays.Count; i++)
            {
                arrays[i] = arrays[i].Trim();
                while (arrays[i].Contains("  "))
                {
                    arrays[i] = arrays[i].Replace("  ", " ");
                }
            }

            Console.WriteLine(string.Join(' ', arrays));

        }
    }
}