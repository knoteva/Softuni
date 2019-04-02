using System;
using System.Collections.Generic;
using System.Linq;

internal class GenericArraySort
{
    private static void Main()
    {
        int[] numbers = {1, 3, 4, 5, 1, 0, 5, -5};
        string[] strings = {"zaz", "cba", "baa", "azis"};
        DateTime[] dates =
        {
            new DateTime(2002, 3, 1),
            new DateTime(2015, 5, 6),
            new DateTime(2014, 1, 1),
        };
       Console.WriteLine(SortArray(numbers));
       Console.WriteLine(SortArray(strings));
       Console.WriteLine(SortArray(dates));
    }
    private static string SortArray<T>(IEnumerable<T> arr)
    {
        List<T> temp = arr.ToList();
        List<T> sorted = new List<T>();
        //temp.Sort();
        while (temp.Count > 0)
        {
            var x = temp.Min();
            sorted.Add(x);
            temp.Remove(x);
        }
        //return String.Join(", ", temp);
        return String.Join(", ", sorted);
    }
}
