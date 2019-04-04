using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));
            //Console.WriteLine($"{GetSumOfEvenDigits(num)}");
            //Console.WriteLine($"{GetMultipleOfEvenAndOdds(num)}");
            Console.WriteLine(GetMultipleOfEvenAndOdds(num));


        }

        private static int GetSumOfEvenDigits(int num)
        {
            int currDigit = 0;
            int sum = 0;
            while (num > 0)
            {
                currDigit = num % 10;

                if (currDigit % 2 == 0)
                    sum = sum + currDigit;

                num = num / 10;
            }
            return sum;
        }

        private static int GetSumOfOddDigits(int num)
        {
            int currDigit = 0;
            int sum = 0;
            while (num > 0)
            {
                currDigit = num % 10;

                if (currDigit % 2 != 0)
                    sum = sum + currDigit;

                num = num / 10;
            }
            return sum;
        }

        private static int GetMultipleOfEvenAndOdds(int num)
        {

            return GetSumOfEvenDigits(num) * GetSumOfOddDigits(num);
        }
    }
}
