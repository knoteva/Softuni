using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StringLength
{
    static void Main()
    {
        string input = Console.ReadLine();
        string result = input;
        if (input.Length > 20)
        {
            result = input.Substring(0, 20);
        }
        else
        {
            while (result.Length < 20)
            {
            result += "*";
            } 
        }
        Console.WriteLine(result);
    }
}

