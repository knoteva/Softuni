using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem07AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine()
                .Split(' ')
                //.Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
            var firstCar = new List<int>();
            var secondCar = new List<int>();
            double speedFirstCar = 0;
            double speedSecondCar = 0;
            double betsTime = 0;
            string winner = "";

            for (int i = 0; i < arrays.Count / 2; i++)
            {
                firstCar.Add(int.Parse(arrays[i]));
            }
            arrays.Reverse();
            for (int i = 0; i < arrays.Count / 2; i++)
            {
                secondCar.Add(int.Parse(arrays[i]));
            }
            //Console.WriteLine(string.Join(' ', secondCar));
            foreach (var car in firstCar)
            {
                if (car == 0)
                {
                    speedFirstCar *= 0.8;
                }
                else
                {
                    speedFirstCar += car;
                }
            }
            foreach (var car in secondCar)
            {
                if (car == 0)
                {
                    speedSecondCar *= 0.8;
                }
                else
                {
                    speedSecondCar += car;
                }
            }
            if (speedFirstCar < speedSecondCar)
            {
                betsTime = speedFirstCar;
                winner = "left";
            }
            else
            {
                betsTime = speedSecondCar;
                winner = "right";
            }
            Console.WriteLine($"The winner is {winner} with total time: {betsTime}");
            // Console.WriteLine(speedSecondCar);
        }
    }
}