using System;
using System.Linq;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = 0; i < lines; i++)
            {
                long[] numbers = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => long.Parse(x))
               .ToArray();

                long leftNum = numbers[0];
                long rightNum = numbers[1];
                if (leftNum > rightNum)
                {
                    leftNum = Math.Abs(leftNum);
                    result = leftNum.ToString().Sum(c => c - '0');
                }
                else
                {
                    rightNum = Math.Abs(rightNum);
                    result = rightNum.ToString().Sum(c => c - '0');
                }
                Console.WriteLine(result);
            }
        }
    }
}
