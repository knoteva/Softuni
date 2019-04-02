using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class VladkoNotebook
{
    static void Main()
    {
        var result = new SortedDictionary<string, SortedDictionary<string, List<string>>>();
        string line = Console.ReadLine();
        while (line !="END")
        {
            string[] data = line.Split('|');
            string color = data[0];
            if (!result.ContainsKey(color))
            {
                result.Add(color, new SortedDictionary<string, List<string>>());
            }
            if (data[1] == "age" )
            {
                if (!result[color].ContainsKey("age"))
                {
                    result[color].Add(data[1], new List<string>());
                }
                
            }
        }
        Console.WriteLine();
    }
}

