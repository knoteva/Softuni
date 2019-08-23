using System;
using System.Text.RegularExpressions;

namespace _01._Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"^(?<peak>[a-zA-Z0-9!@#$?]+)=(?<length>[0-9]+)<<(?<code>.+)";

            string line;
            while ((line = Console.ReadLine()) != "Last note")
            {
                Match m = Regex.Match(line, regex);

                if (!m.Success)
                {
                    Console.WriteLine("Nothing found!");
                }
                else
                {
                    string peak = m.Groups["peak"].Value;
                    int length = int.Parse(m.Groups["length"].Value);
                    string code = m.Groups["code"].Value;

                    if (length != code.Length)
                    {
                        Console.WriteLine("Nothing found!");
                    }
                    else
                    {
                        Regex rgx = new Regex(@"[^a-zA-Z0-9]");
                        string nameOfMountain = rgx.Replace(peak, "");
                        Console.WriteLine($"Coordinates found! {nameOfMountain} -> {code}");
                    }
                }
            }
        }
    }
}
