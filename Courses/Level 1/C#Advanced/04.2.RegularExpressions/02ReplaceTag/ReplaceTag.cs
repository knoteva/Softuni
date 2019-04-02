using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ReplaceTag
{
    static void Main(string[] args)
    {
        string input = "<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>";
        string regex = "<a([\\s\\S]*?)>([\\s\\S]*?)<\\/a>";
        var data = Regex.Matches(input, regex);
        foreach (Match match in data)
        {
            Console.WriteLine("[URL" + match.Groups[1] + "]" + match.Groups[2] +
                match.Groups[3] + "[/URL]");
        }
    }
}

