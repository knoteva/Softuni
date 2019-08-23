using System;

namespace _01._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int companions = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int totalCoins = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 10 == 0)
                {
                    companions -= 2;
                }
                if (i % 15 == 0)
                {
                    companions += 5;
                }
                totalCoins += 50 - 2 * companions;
                if (i % 3 == 0)
                {
                    totalCoins -= 3 * companions;
                }
                if (i % 5 == 0)
                {
                    totalCoins += 20 * companions;
                    if (i % 3 == 0)
                    {
                        totalCoins -= 2 * companions;
                    }
                }
            }
            Console.WriteLine($"{companions} companions received {totalCoins / companions} coins each.");
        }
    }
}
