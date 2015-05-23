using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class LittleJohn
{
    static void Main()
    {
        string[] line = new string[4];
        Regex regex = new Regex(@"(>>>----->>)|(>>----->)|(>----->)");
        int large = 0;
        int medium = 0;
        int small = 0;
        for (int i = 0; i < 4; i++)
        {
            line[i] = Console.ReadLine();
            var arrows = regex.Matches(line[i]);

            foreach (Match arrow in arrows)
            {
                if (!string.IsNullOrEmpty((arrow.Groups[1].Value)))
                {
                    large++;
                }
                else if (!string.IsNullOrEmpty(arrow.Groups[2].Value))
                {
                    medium++;
                }
                else
                {
                    small++;
                }
            }

        }
        int dec = Convert.ToInt32("" + small + medium + large);
        var binary = Convert.ToString(dec, 2).ToList();
        string binaryResult = string.Join("", binary);
        binary.Reverse();
        binaryResult += string.Join("", binary);
        long result = Convert.ToInt64(binaryResult, 2);
        Console.WriteLine(result);
    }
}

