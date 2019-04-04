using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine().ToLower();
            CountVowels(str);
        }

        private static void CountVowels(string str)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            int total = str.Count(c => vowels.Contains(c));
            Console.WriteLine(total);
        }
    }
}
