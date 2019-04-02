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
       // Console.WriteLine("Found {0} matches", matches.Count);
        foreach (Match match in matches)
        {
            for (int i = 1; i < match.Groups.Count; i++)
            {
                if (match.Groups[i].Value != string.Empty)
                {
                    Console.WriteLine(match.Groups[i].Value);
                }
            }
        }
    }
}

