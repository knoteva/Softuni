using System;

namespace _5._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            ReturnSign(numberOne, numberTwo, numberThree);
        }

        private static void ReturnSign(int numberOne, int numberTwo, int numberThree)
        {
            int[] numbers = { numberOne, numberTwo, numberThree };
            int countOfNegative = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    countOfNegative++;
                }
            }

            if (numberOne == 0 || numberTwo == 0 || numberThree == 0)
            {
                Console.WriteLine("zero");
            }

            else if (countOfNegative % 2 == 0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}