using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Phonebook
{
    static void Main()
    {
        string firstLine = Console.ReadLine();
        var phonebook = new Dictionary<string, List<string>>();
        while (firstLine != "search")
        {
            string[] input = firstLine.Split('-');
            if (!phonebook.ContainsKey(input[0]))
            {
                phonebook[input[0]] = new List<string>();
            }
            phonebook[input[0]].Add(input[1]);
            firstLine = Console.ReadLine();
        }
        firstLine = Console.ReadLine();
        while (!firstLine.Equals(""))
        {
            if (phonebook.ContainsKey(firstLine))
            {
                Console.WriteLine("{0} -> {1}", firstLine, string.Join(", ", phonebook[firstLine]));
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", firstLine);
            }

            firstLine = Console.ReadLine();
        }
    }
}

