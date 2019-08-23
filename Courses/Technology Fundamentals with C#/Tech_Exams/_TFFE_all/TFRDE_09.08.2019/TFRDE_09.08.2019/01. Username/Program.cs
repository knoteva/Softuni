using System;
using System.Linq;

namespace _01._Username_Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Sign up")
            {
                string command = line.Split(" ")[0];

                if (command == "Case")
                {
                    var lowerUpper = line.Split(" ")[1];
                    if (lowerUpper == "lower")
                    {
                        str = str.ToLower();
                    }
                    else
                    {
                        str = str.ToUpper();
                    }
                    Console.WriteLine(str);
                }
                else if (command == "Reverse")
                {
                    var startIndex = int.Parse(line.Split(" ")[1]);
                    var endIndex = int.Parse(line.Split(" ")[2]);

                    if (startIndex >= 0 && endIndex <= str.Length - 1 && startIndex <= endIndex)
                    {
                        int length = endIndex - startIndex;
                        var reverse = str.Substring(startIndex, length + 1).Reverse().ToArray();
                        Console.WriteLine(reverse);
                    }
                }
                else if (command == "Cut")
                {
                    var substring = line.Split(" ")[1];
                    if (!str.Contains(substring))
                    {
                        Console.WriteLine($"The word {str} doesn't contain {substring}.");
                    }
                    else
                    {
                        str = str.Replace(substring, "");
                        Console.WriteLine(str);
                    }
                }
                else if (command == "Replace")
                {
                    var ch = line.Split(" ")[1].ToCharArray()[0];
                    str = new string(str.Select(r => r == ch ? '*' : r).ToArray());
                    Console.WriteLine(str);
                }
                else if (command == "Check")
                {
                    var ch = line.Split(" ")[1].ToCharArray()[0];
                    if (str.Contains(ch))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {ch}.");
                    }
                }
            }
        }
    }
}
