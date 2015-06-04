using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class UseYourChainsBuddy
{
    static void Main()
     {
        string input = Console.ReadLine();
        var regex = new Regex("<p>(.*?)</p>");
        var matches = regex.Matches(input);
        string extract = "";
        string result = "";
        foreach (Match m in matches)
        {
            extract += m.Groups[1].ToString();
            extract = Regex.Replace(extract, @"[^a-z0-9]", " ");   
        }
        extract = Regex.Replace(extract, @"\s+", " ");
        for (int i = 0; i < extract.Length; i++)
        {


            if (extract[i] >= 'a' && extract[i] <= 'm')
            {
                result += (char)(extract[i] + 13);
            }
            else if (extract[i] >= 'n' && extract[i] <= 'z')
            {
                result += (char)(extract[i] - 13);
            }
            else
                result += extract[i];
        }
        Console.WriteLine(result);
    }
}

