using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            var gameWithNoDLC = new Dictionary<string, double>();
            var gameWithDLC = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("-"))
                {
                    string game = input[i].Split("-")[0];
                    double price = double.Parse(input[i].Split("-")[1]);
                    gameWithNoDLC.Add(game, price);
                    
                }
                else
                {
                    string game = input[i].Split(":")[0];
                    string dlc = input[i].Split(":")[1];
                    if (gameWithNoDLC.ContainsKey(game))
                    {
                        gameWithDLC.Add(game, new Dictionary<string, double>());
                        gameWithDLC[game].Add(dlc, gameWithNoDLC[game] * 1.2);
                        gameWithNoDLC.Remove(game);
                    }
                }
            }

            foreach (var kvp in gameWithDLC.OrderBy(x => x.Value.Values.Max()))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value.Keys.First()} - {kvp.Value.Values.First() * 0.5:F2}");
            }

            foreach (var game in gameWithNoDLC.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{game.Key} - {game.Value*0.8:F2}");
            }
        }
    }
}
