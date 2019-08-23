using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = Console.ReadLine().Split(" ");
            string word1 = words[0];
            string word2 = words[1];
            StringBuilder decripted = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                decripted.Append((char)(input[i] - 3));
            }
            string regex = @"^[d-z#|{}]+$";
            MatchCollection matched = Regex.Matches(input, regex);
            if (matched.Count == 0)
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }
            decripted.Replace(word1, word2);
            Console.WriteLine(decripted);

        }
    }
}
