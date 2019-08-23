using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._Animal_Sanctuary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string regex = @"n:(?<name>[^;]+);t:(?<kind>[^;]+);c--(?<country>[A-Za-z ]+)";
            int weigth = 0;

            for (int i = 0; i < n; i++)
            {
                string animal = Console.ReadLine();
                Match m = Regex.Match(animal, regex);

                if (m.Success)
                {
                    string name = m.Groups["name"].Value;
                    string kind = m.Groups["kind"].Value;
                    string country = m.Groups["country"].Value;

                    weigth += double.Parse(new string(name.Where(c => char.IsDigit(c)).ToArray())).ToString().Sum(c => c - '0');
                    weigth += double.Parse(new string(kind.Where(c => char.IsDigit(c)).ToArray())).ToString().Sum(c => c - '0');
                    name = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                    kind = new string(kind.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                    Console.WriteLine($"{name} is a {kind} from {country}");
                }
            }

            Console.WriteLine($"Total weight of animals: {weigth}KG");
        }
    }
}
