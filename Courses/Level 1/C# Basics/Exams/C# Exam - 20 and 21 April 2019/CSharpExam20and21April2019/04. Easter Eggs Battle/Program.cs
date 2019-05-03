using System;

namespace _04._Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int player1Eggs = int.Parse(Console.ReadLine());
            int player2Eggs = int.Parse(Console.ReadLine());
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End of battle")
            {               
                if (command == "one")
                {
                    //player1Eggs++;
                    player2Eggs--;
                }
                else if (command == "two")
                {
                    player1Eggs--;
                    //player2Eggs++;
                }

                if (player1Eggs == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {player2Eggs} eggs left.");
                    return;
                }
                if (player2Eggs == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {player1Eggs} eggs left.");
                    return;
                }
            }
            Console.WriteLine($"Player one has {player1Eggs} eggs left.");
            Console.WriteLine($"Player two has {player2Eggs} eggs left.");
        }
    }
}
