using System;
using System.Linq;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
               .Split(" ")
               .ToList();
            string input;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string command = input.Split(" ")[0];
                if (command == "Delete")
                {
                    int index = int.Parse(input.Split(" ")[1]) + 1;

                    if (index >= 0 && index < list.Count)
                    {
                        list.RemoveAt(index);
                    }
                }
                else if (command == "Swap")
                {
                    string word1 = input.Split(" ")[1];
                    string word2 = input.Split(" ")[2];

                    if (list.Contains(word1) && list.Contains(word2))
                    {
                        int index1 = list.IndexOf(word1);
                        int index2 = list.IndexOf(word2);
                        list.RemoveAt(index1);
                        list.Insert(index1, word2);
                        list.RemoveAt(index2);
                        list.Insert(index2, word1);
                    }
                }
                else if (command == "Put")
                {
                    string word = input.Split(" ")[1];
                    int index = int.Parse(input.Split(" ")[2]) - 1;

                    if (index >= 0 && index <= list.Count)
                    {
                        list.Insert(index, word);
                    }
                }
                else if (command == "Sort")
                {
                    list = list.OrderByDescending(x => x).ToList();
                }
                else if (command == "Replace")
                {
                    string word1 = input.Split(" ")[1];
                    string word2 = input.Split(" ")[2];
                    if (list.Contains(word2))
                    {
                        list[list.IndexOf(word2)] = word1;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
