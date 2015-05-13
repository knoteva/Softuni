using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TextFilter
{
    static void Main()
    {
        string[] banList = Console.ReadLine().Split(',').Select(b => b.Trim()).ToArray();
        string text = Console.ReadLine();
        foreach (var ban in banList)
        {
           string replace = new string('*', ban.Length);
           text = text.Replace(ban, replace);           
        }      
        Console.WriteLine(text);
    }
}

