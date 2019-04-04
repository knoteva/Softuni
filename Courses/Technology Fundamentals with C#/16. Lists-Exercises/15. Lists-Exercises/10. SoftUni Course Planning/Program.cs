using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine()
                .Split(", ")
                .ToList();
            string[] lines = Console.ReadLine().Split(":");
            while (lines[0] != "course start")
            {
               if (lines[0] == "Add")
                {
                    if (!sequence.Contains(lines[1])) {
                        sequence.Add(lines[1]);
                    }
                    
                }
                if (lines[0] == "Insert")
                {
                    if (!sequence.Contains(lines[1]) && int.Parse(lines[2]) >= 0 && int.Parse(lines[2]) < sequence.Count)
                    {
                        sequence.Insert(int.Parse(lines[2]), lines[1]);
                    }

                }
                if (lines[0] == "Remove")
                {
                    if (sequence.Contains(lines[1]))
                    {
                        sequence.Remove(lines[1]);
                        if (sequence.Contains(lines[1] + "-Exercise"))
                        {
                            sequence.Remove(lines[1] + "-Exercise");
                        }
                    }

                    
                }
                if (lines[0] == "Swap")
                {
                    if (sequence.Contains(lines[1]) && sequence.Contains(lines[2]))
                    {              
                        int firstIndex = sequence.IndexOf(lines[1]);
                        string firstTitle = lines[1];
                        int secondIndex = sequence.IndexOf(lines[2]);
                        string secondTitle = lines[2];

                        sequence.Remove(lines[1]);
                        sequence.Remove(lines[2]);
                        sequence.Insert(firstIndex, secondTitle);
                        sequence.Insert(secondIndex, firstTitle);
                        if (sequence.Contains(firstTitle + "-Exercise"))
                        {
                            sequence.Remove(firstTitle + "-Exercise");
                            sequence.Insert(secondIndex + 1, firstTitle + "-Exercise");
                        }
                        if (sequence.Contains(secondTitle + "-Exercise"))
                        {
                            sequence.Remove(secondTitle + "-Exercise");
                            sequence.Insert(firstIndex + 1, secondTitle + "-Exercise");
                        }
                    }
                }
                if (lines[0] == "Exercise")
                {
                    if (sequence.Contains(lines[1]))
                    {
                        int index = sequence.IndexOf(lines[1]);
                        sequence.Insert(index, lines[1] + "-Exercise");
                    }
                    else
                    {
                        sequence.Add(lines[1]);
                        sequence.Add(lines[1] + "-Exercise");
                    }

                }

                lines = Console.ReadLine().Split(":");
            }

            for (int i = 0; i < sequence.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{sequence[i]}");
            }
        }


        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
