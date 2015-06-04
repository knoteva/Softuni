using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

class QueryMess
{
    static void Main()
    {
        string input = Console.ReadLine();
        var regex = new Regex(@"([^=&?]+)=([^=&?]+)");
        var whiteSpace = new Regex(@"(\+|%20)+");
        var result = new Dictionary<string, List<string>>();

        while (input != "END")
        {
            input = whiteSpace.Replace(input, " ");

            var matches = regex.Matches(input);

            foreach (Match m in matches)
            {
                var key = m.Groups[1].ToString().Trim();
                var value = m.Groups[2].ToString().Trim();
                if (!result.ContainsKey(key))
                {
                    result.Add(key, new List<string>());
                }           
                result[key].Add(value);
               }
            input = Console.ReadLine();
            foreach (var key in result.Keys)
            {
                Console.Write(key + "=[" + string.Join(", ", result[key]) + "]");
            }
            Console.WriteLine();
            result.Clear();         
        }
    }
}

