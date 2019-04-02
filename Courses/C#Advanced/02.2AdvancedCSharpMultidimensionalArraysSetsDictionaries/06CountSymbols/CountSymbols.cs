using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountSymbols
{
    static void Main()
    {
        string text = Console.ReadLine();
        var result = new SortedDictionary<char, int>();
        foreach (var s in text)
        {
            if (!result.ContainsKey(s))
            {
                result[s] = 1;
            }
            else
            {
                result[s]++;
            }
        }
        foreach (var res in result)
        {
            Console.WriteLine("{0}: {1} time/s", res.Key, res.Value);
        }
    }
}

