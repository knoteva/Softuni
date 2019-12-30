using System;
using System.Linq;

namespace _01._Summer_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredient = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var freshness = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            while (ingredient.Count > 0 && freshness.Count > 0)
            {

            }
        }
    }
}
