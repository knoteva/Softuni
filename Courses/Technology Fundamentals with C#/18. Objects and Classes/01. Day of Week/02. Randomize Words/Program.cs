using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            Random rnd = new Random();
            for (int pos1 = 0; pos1 < words.Length; pos1++)
            {
                int pos2 = rnd.Next(0, words.Length-1);
                string curr = words[pos1];
                words[pos1] = words[pos2];
                words[pos2] = curr;
            }
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
