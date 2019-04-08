using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem10RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = Console.ReadLine().Split(" ");
            string word1 = words[0];
            string word2 = words[1];

            string regex = @"^[d-z#|]+$";
            MatchCollection matched = Regex.Matches(input, regex);
            if (matched.Count == 0)
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }

            //Console.WriteLine(input);
            StringBuilder decripted = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                decripted.Append((char)(input[i] - 3));
            }
            decripted.Replace(word1, word2);
            Console.WriteLine(decripted);
        }
    }
}