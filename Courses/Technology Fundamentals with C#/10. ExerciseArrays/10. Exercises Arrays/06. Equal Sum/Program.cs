using System;
using System.Linq;
namespace Equal_sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            if (nums.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                leftSum = nums.Take(i).Sum();

                rightSum = nums.Skip(i + 1).Sum();

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}