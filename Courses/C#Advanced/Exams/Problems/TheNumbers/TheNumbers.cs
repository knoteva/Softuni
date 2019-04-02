using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class TheNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        var regex = new Regex(@"\d+");
        var matches = regex.Matches(input);
        var result = new List<string>();
        foreach (Match match in matches)
        {
            var dec = Convert.ToInt32(match.ToString());
            var hex = dec.ToString("X");
            hex = hex.PadLeft(4, '0');
            hex = "0x" + hex;
            result.Add(hex);
           
        }
        Console.WriteLine(string.Join("-", result));
    }
}

