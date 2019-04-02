using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            double volume = 0;
            double maxVolume = double.MinValue;
            string type = "";
            for (int i = 0; i < lines; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                volume = Math.PI * radius * radius * height;
                if (volume > maxVolume )
                {
                    maxVolume = volume;
                    type = model;
                }
            }
            Console.WriteLine($"{type}");
        }
    }
}
