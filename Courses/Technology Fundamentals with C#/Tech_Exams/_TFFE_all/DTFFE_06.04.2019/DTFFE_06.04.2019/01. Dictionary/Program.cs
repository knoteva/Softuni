using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>(); // firstString

            string[] input = Console.ReadLine().Split(" | ");

            string[] words = Console.ReadLine().Split(" | ");

            for (int i = 0; i < input.Length; i++)
            {
                string[] wordDefinition = input[i].Split(": ");

                string word = wordDefinition[0];
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                }

                string definition = wordDefinition[1];
                dictionary[word].Add(definition);
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (dictionary.ContainsKey(words[i]))
                {
                    Console.WriteLine(words[i]);
                    foreach (var definition in dictionary[words[i]].OrderByDescending(x => x.Length))
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }
            }

            string command = Console.ReadLine(); //// thirdString
            if (command == "List")
            {              
                Console.WriteLine(string.Join(" ", dictionary.OrderBy(x => x.Key).Select(x => $"{x.Key}")));

                //var listOfWords = new List<string>();
                //foreach (var word in dictionary.OrderBy(x => x.Key))
                //{
                //    listOfWords.Add(word.Key);
                //}
                //Console.WriteLine(string.Join(" ", listOfWords));
            }
        }
    }
}
