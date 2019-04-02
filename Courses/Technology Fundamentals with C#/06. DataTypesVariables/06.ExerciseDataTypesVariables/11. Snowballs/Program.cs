using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger value = 0;
            BigInteger maxValue = int.MinValue;
            int finalSnowballSnow = 0;
            int finalSnowballTime = 0;
            int finalSnowballQuality = 0;
            for (int i = 1; i <= n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                value = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);              
                if (maxValue <= value)
                {
                    maxValue = value;
                    finalSnowballSnow = snowballSnow;
                    finalSnowballTime = snowballTime;
                    finalSnowballQuality = snowballQuality;
                }
            }
            Console.WriteLine($"{finalSnowballSnow} : {finalSnowballTime} = {maxValue} ({finalSnowballQuality})");
        }
    }
}
