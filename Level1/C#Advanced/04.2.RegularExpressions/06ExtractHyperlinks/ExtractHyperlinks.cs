using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ExtractHyperlinks
{
    private static void Main()
    {
        StringBuilder sb = new StringBuilder();
        string firstLine;
        Regex regex = new Regex(@"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>");
        while ((firstLine = Console.ReadLine()) != "END")
        {
            sb.Append(firstLine);
        }
        string text = sb.ToString();

        var matches = regex.Matches(text);

        foreach (Match hyperlink in matches)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (hyperlink.Groups[i].Length > 0)
                {
                    Console.WriteLine(hyperlink.Groups[i]);
                }
            }
        }
    }
}