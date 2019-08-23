using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string message = Console.ReadLine();
                string regex = @"([#$%*&])(?<racer>[A-Za-z]+)(\1)=(?<length>[0-9]+)!!(?<code>.+)$";
                Match m = Regex.Match(message, regex);

                if (!m.Success)
                {
                    Console.WriteLine($"Nothing found!");
                }
                else
                {
                    string racer = m.Groups["racer"].Value;
                    int length = int.Parse(m.Groups["length"].Value);
                    string code = m.Groups["code"].Value;

                    if (length != code.Length)
                    {
                        Console.WriteLine($"Nothing found!");
                    }
                    else
                    {
                        string replacedString = new string(code.Select(r => r = (char)(r + length)).ToArray());
                        Console.WriteLine($"Coordinates found! {racer} -> {replacedString}");
                        return;
                    }
                }
            }
        }
    }
}
