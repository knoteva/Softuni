using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class UppercaseWordsSB
{
    static void Main()
    {
        var regex = new Regex(@"[a-zA-Z]+");
        var sb = new StringBuilder();
        string line = Console.ReadLine();
        string result = "";

        while (line != "END")
        {
            sb.Append(line);
            sb.Append("\n");
            line = Console.ReadLine();
        }
        string text = sb.ToString();
        result = regex.Replace(text, (m => ReturnNewWord(m.ToString())));
        Console.WriteLine(SecurityElement.Escape(result));
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

