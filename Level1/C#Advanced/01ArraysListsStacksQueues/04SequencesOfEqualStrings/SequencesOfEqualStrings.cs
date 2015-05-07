using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequencesOfEqualStrings
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        List<string> elements = new List<string>();
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i - 1].CompareTo(input[i]) == 0)
            {
                elements.Add(input[i - 1]);
            }
            else
            {
                elements.Add(input[i - 1]);
                Console.WriteLine(String.Join(" ", elements));
                elements.Clear();
            }
        }
        elements.Add(input[input.Length - 1]);
        Console.WriteLine(String.Join(" ", elements));
    }
}

