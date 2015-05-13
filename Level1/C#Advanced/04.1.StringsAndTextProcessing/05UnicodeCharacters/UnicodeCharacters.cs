using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();
        foreach (var ch in input)
        {
            Console.Write("\\u{0}", ((int)ch).ToString("x4"));
        }
        Console.WriteLine();
    }
}

