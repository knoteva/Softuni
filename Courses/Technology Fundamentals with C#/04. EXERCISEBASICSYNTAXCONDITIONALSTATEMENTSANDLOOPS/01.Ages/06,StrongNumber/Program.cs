using System;

namespace _06_StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int digit = 0;
            int f = 1;
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                digit = (int)Char.GetNumericValue(num[i]);
                int fact = digit;
                for (int j = 1; j < digit; j++)
                {
                    fact = fact * j;                   
                }
                sum += fact;
            }
            if (Convert.ToInt32(num) == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            
        }
    }
}
