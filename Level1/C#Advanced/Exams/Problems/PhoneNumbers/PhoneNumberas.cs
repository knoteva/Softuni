using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class PhoneNumberas
{
    static void Main()
    {
        var regex = new Regex(@"([A-Z][A-Za-z]*)[^0-9A-Za-z+]*([+]?[0-9]+[0-9- ./)\(]*[0-9]+)");
        var reg = new Regex(@"[- ./)\(]");
        string line = Console.ReadLine();
        var result = new Dictionary<string, string>();
       // int count = 0;
        string key = "";
         string value = "";
        string output = "<ol>";
        
        while (line !="END")
        {
            var matches = regex.Matches(line);
                foreach (Match m in matches)
                {
                key = m.Groups[1].ToString().Trim();
                value = m.Groups[2].ToString().Replace("-", "");
                value = reg.Replace(value, "");
                result.Add(key, value);
                 }   
                line = Console.ReadLine();
                foreach (var res in result.Keys)
                {
                    output += "<li><b>" + res + ":</b> " + result[res] + "</li>";
                }
                   // Console.WriteLine("<p>No matches!</p>");                                     
        }
        if (output == "<ol>")
        {
            Console.WriteLine("<p>No matches!</p>");
        }
        else
        {
            output += "</ol>";
            Console.Write(output);
        }
       
    }
}

