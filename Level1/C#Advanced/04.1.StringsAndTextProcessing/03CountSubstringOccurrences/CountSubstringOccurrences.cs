using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class CountSubstringOccurrences
{
    private static void Main()
    {
        string text = Console.ReadLine().ToLower();
        string search = Console.ReadLine().ToLower();
        int count = text.Select((c, i) => text.Substring(i)).Count(sub => sub.StartsWith(search));
        Console.WriteLine(count);
    }
}

