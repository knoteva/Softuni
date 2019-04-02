using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(ReverseWithChar(input));
        Console.WriteLine(ReverseWithLoop(input));
    }

    static string ReverseWithChar(string text)
    {
        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new String(array);
    }

    static string ReverseWithLoop(string text)
    {
        string result = "";
        for (int i = text.Length - 1; i >= 0 ; i--)
        {
            result += text[i];
          
        }
        return result;
    }
}

