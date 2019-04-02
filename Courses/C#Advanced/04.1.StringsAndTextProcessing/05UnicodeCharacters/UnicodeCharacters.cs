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
            int num = Convert.ToInt32(ch));
            Console.Write("\\u{0:x4}", num);
        }
        Console.WriteLine();
    }
}

