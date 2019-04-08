using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new SortedDictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" | ");
            string[] words = Console.ReadLine().Split(" | ");
            string command = Console.ReadLine();
            var listOfWords = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] wordDefinition = input[i].Split(": ");

                string word = wordDefinition[0];
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                }
                dictionary[word].Add(wordDefinition[1]);
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
            if (command == "List")
            {
                foreach (var word in dictionary)
                {
                    listOfWords.Add(word.Key);
                }
                Console.WriteLine(string.Join(" ", listOfWords));
            }
        }
    }
}