using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ExtractEmails
{
    static void Main()
    {
        string input = Console.ReadLine();
        string regex = @"\s([a-zA-Z\d][a-zA-Z\d\.\-_]*[a-zA-Z\d]@(?:[a-zA-Z][a-zA-Z\-]*[a-zA-Z]\.){1,}[a-zA-Z][a-zA-Z\-]*[a-zA-Z])";
        var matches = Regex.Matches(input, regex);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Groups[1]);
        }
    }
}

