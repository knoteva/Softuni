using System;

namespace _06._High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int startHeight = height - 30;
            int failedJumps = 0;
            int allJumps = 0;

            while (startHeight <= height)
            {
                int jump = int.Parse(Console.ReadLine());
                if (jump > startHeight)
                {
                    startHeight += 5;
                    failedJumps = 0;
                    allJumps++;
                }
                else
                {
                    allJumps++;
                    failedJumps++;
                }
                if (failedJumps == 3)
                {
                    Console.WriteLine($"Tihomir failed at {startHeight}cm after {allJumps} jumps.");
                    return;
                }
            }
            Console.WriteLine($"Tihomir succeeded, he jumped over {startHeight - 5}cm after {allJumps} jumps.");
        }
    }
}
