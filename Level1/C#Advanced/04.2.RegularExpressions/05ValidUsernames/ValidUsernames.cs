using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

internal class ValidUsernames
{
    private static void Main()
    {
        string[] input = Console.ReadLine().Split('\\', '/', '(', ')', ' ');
        Regex regex = new Regex(@"\b[a-zA-Z][a-zA-Z0-9_]{2,24}\b");
        var valid = new List<string>();
        foreach (var i in input)
        {
            if (regex.IsMatch(i))
            {
                valid.Add(i);
            }
        }
        int sum = 0;
        int maxSum = 0;
        string result = "";
        for (int i = 1; i < valid.Count; i++)
        {
            sum = valid[i - 1].Length + valid[i].Length;
            if (sum > maxSum)
            {
                maxSum = sum;
                result = valid[i - 1] + "\n" + valid[i];
            }
        }
        Console.WriteLine(result);

        //valid = new List<string>(SortByLength(valid));
        ////foreach (var i in valid)
        ////{
        ////    Console.WriteLine(i);
        ////}
        //Console.WriteLine(valid[1]);
        //Console.WriteLine(valid[0]);
    }

    //private static IEnumerable<string> SortByLength(IEnumerable<string> list)
    //{
    //    // Use LINQ to sort the array received and return a copy.
    //    var sorted = from word in list
    //        orderby word.Length descending 
    //        select word;
    //    return sorted;
    //}
}

 