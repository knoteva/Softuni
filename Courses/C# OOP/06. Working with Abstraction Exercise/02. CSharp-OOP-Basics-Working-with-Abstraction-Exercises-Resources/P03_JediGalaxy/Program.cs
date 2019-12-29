using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimestions[0];
            int cols = dimestions[1];

            var board = new Board(rows, cols);          

            string command = Console.ReadLine();

            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] playerCoor = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoor = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var evil = new Player
                {
                    Row = evilCoor[0],
                    Col = evilCoor[1]
                };

                while (evil.Row >= 0 && evil.Col >= 0)
                {
                    if (board.IsInside(evil.Row, evil.Col))
                    {
                        board.Matrix[evil.Row, evil.Col] = 0;
                    }
                    evil.Row--;
                    evil.Col--;
                }

                var player = new Player
                {
                    Row = playerCoor[0],
                    Col = playerCoor[1]
                };

                while (player.Row >= 0 && playerCoor[1] < board.Matrix.GetLength(1))
                {
                    if (board.IsInside(player.Row, playerCoor[1]))
                    {
                        sum += board.Matrix[player.Row, playerCoor[1]];
                    }

                    playerCoor[1]++;
                    player.Row--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        
    }
}
