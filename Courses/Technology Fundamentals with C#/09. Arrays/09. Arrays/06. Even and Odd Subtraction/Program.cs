using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int even = 0;
            int odd = 0;
            int sum = 0;
            foreach (int value in nums)
            {
                if (value % 2 == 0)
                {
                    even += value;
                }
                else if (value % 2 != 0)
                {
                    odd += value;
                }
            }
            sum = even - odd;
            Console.WriteLine(sum);
        }
    }
}
