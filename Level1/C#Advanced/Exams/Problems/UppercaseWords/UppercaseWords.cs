using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

internal class UppercaseWords
{
    private static void Main()
    {
        string input = Console.ReadLine();
        const string pattern = @"[a-zA-Z]+";
        var regex = new Regex(pattern);
        while (true)
        {
            if (input == "END")
            {
                break;
            }
            var result = regex.Replace(input, (m => ReturnNewWord(m.ToString())));
            input = Console.ReadLine();
            Console.WriteLine(SecurityElement.Escape(result));
        }
    }

    private static string ReturnNewWord(string word)
    {
        string output = new string(word.Reverse().ToArray());
        if (word == word.ToUpper())
        {
            if (word == output)
            {
                return word.Aggregate("", (current, w) => current + ("" + w + w));
            }
            return output;
        }
        return word;
    }
}