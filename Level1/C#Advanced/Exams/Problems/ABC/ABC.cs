using System;

class ABC
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        double mean = (a + b + c) / (double)3;
        Console.WriteLine(Math.Max(a, Math.Max(b, c)));
        Console.WriteLine(Math.Min(a, Math.Min(b, c)));
        Console.WriteLine("{0:F3}", mean);
    }
}
