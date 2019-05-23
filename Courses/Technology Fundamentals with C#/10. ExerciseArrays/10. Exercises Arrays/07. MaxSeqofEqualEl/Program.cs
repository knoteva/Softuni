using System;
using System.Linq;

namespace _07._MaxSeqofEqualEl
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int maxCount = 0;
            int maxNumber = 0;
            for (int row = 0; row < numbers.Count; row++)
            {

                int currCount = 0;
                for (int col = row; col < numbers.Count; col++)
                {

                    if (numbers[row] == numbers[col])
                    {
                        currCount++;

                        if (currCount > maxCount)
                        {
                            maxCount = currCount;
                            maxNumber = numbers[row];
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(maxNumber + " ");
            }
        }
    }
}
