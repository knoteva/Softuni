using System;

namespace _04._Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            int points1 = 0;
            int points2 = 0;


            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End of game")
                {
                    break;
                }
                int card1 = int.Parse(command);
                int card2 = int.Parse(Console.ReadLine());
                if (card1 > card2)
                {
                    points1 += card1 - card2;
                }
                else if(card2 > card1)
                {
                    points2 += card2 - card1;
                }
                else
                {
                    Console.WriteLine("Number wars!");
                    card1 = int.Parse(Console.ReadLine());
                    card2 = int.Parse(Console.ReadLine());
                    if (card1 > card2)
                    {
                        Console.WriteLine($"{name1} is winner with {points1} points");
                    }
                    else
                    {
                        Console.WriteLine($"{name2} is winner with {points2} points");
                    }
                    return;
                }
            }
            Console.WriteLine($"{name1} has {points1} points\n{name2} has {points2} points");
        }
    }
}
