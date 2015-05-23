using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class SentenceExtractor
{
    static void Main()
    {
        string word = Console.ReadLine();
        string input = Console.ReadLine();
        string pattern = @"(?<=\s|^)(.*?\b{0}\b.*?(?=\!|\.|\?)[?.!])";
        MatchCollection matches = Regex.Matches(input, pattern);
        foreach (var match in matches)
        {
            if (match.ToString().Split(' ').Contains(word))
            {
                Console.WriteLine(match);
            }
        }
    }
}

