using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main()
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            MergeList(list1, list2);
        }
        private static void MergeList<T>(List<T> list1, List<T> list2)
        {
            int length = Math.Min(list1.Count, list2.Count); // takes less length of list if any
            for (int i = 0; i < length; i++) // loop trough list with less elements
            {
                list1.Insert(2 * i + 1, list2[i]); // insert after every second element
            }
            if (length < list2.Count) // if second list length is greater add it's remaining elements to the first
            {
                for (int i = length; i < list2.Count; i++)
                {
                    list1.Add(list2[i]);
                }
            }
            Console.WriteLine(string.Join(" ", list1));
        }
    }
}