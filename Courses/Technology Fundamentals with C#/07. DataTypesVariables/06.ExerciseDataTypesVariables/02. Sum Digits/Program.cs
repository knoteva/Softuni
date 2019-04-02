using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int result = 0;
            for (int i = 0; i < num.Length; i++)
            {
                result += (int)Char.GetNumericValue(num[i]);
            }
            Console.WriteLine(result);
        }
    }
}
