using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split(" ")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
            string commandLine = "";
            while ((commandLine = Console.ReadLine()) != "Stop")
            {
                string command = commandLine.Split(" ")[0];

                if (command == "Delete")
                {
                    int desiredIndex = int.Parse(commandLine.Split(" ")[1]) + 1;
                    if (list.Count > desiredIndex && desiredIndex >= 0)
                    {
                        list.RemoveAt(desiredIndex);
                    }
                }
                if (command == "Sort")
                {
                    list.Sort((x, y) => y.CompareTo(x));
                }
                if (command == "Put")
                {
                    string word = commandLine.Split(" ")[1];
                    int desiredIndex = int.Parse(commandLine.Split(" ")[2]) - 1;
                    if (list.Count >= desiredIndex && desiredIndex >= 0)
                    {
                        list.Insert(desiredIndex, word);
                    }
                }
                if (command == "Replace")
                {
                    string word1 = commandLine.Split(" ")[1];
                    string word2 = commandLine.Split(" ")[2];
                    if (list.Contains(word2))
                    {
                        int index = list.IndexOf(word2);
                        list.Remove(word2);
                        list.Insert(index, word1);
                    }
                }
                if (command == "Swap")
                {
                    string word1 = commandLine.Split(" ")[1];
                    string word2 = commandLine.Split(" ")[2];
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
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
