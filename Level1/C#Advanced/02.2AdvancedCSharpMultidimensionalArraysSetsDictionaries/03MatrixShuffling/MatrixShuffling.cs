using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixShuffling
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }
        Console.WriteLine();
        string commands = Console.ReadLine();
        while (!commands.Equals("END"))
        {
            string[] coordinates = commands.Split(' ');
            if (coordinates.Length != 5 || coordinates[0] != "swap" || Convert.ToInt32(coordinates[1]) < 0 || Convert.ToInt32(coordinates[1]) > rows - 1 ||
                Convert.ToInt32(coordinates[2]) < 0 || Convert.ToInt32(coordinates[2]) > cols - 1 ||
                Convert.ToInt32(coordinates[3]) < 0 || Convert.ToInt32(coordinates[3]) > rows - 1 ||
                Convert.ToInt32(coordinates[4]) < 0 || Convert.ToInt32(coordinates[4]) > cols - 1)
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine();
                commands = Console.ReadLine();
                continue;
            }
            string tmp = matrix[Convert.ToInt32(coordinates[1]), Convert.ToInt32(coordinates[2])];
            matrix[Convert.ToInt32(coordinates[1]), Convert.ToInt32(coordinates[2])] = matrix[Convert.ToInt32(coordinates[3]), Convert.ToInt32(coordinates[4])];
            matrix[Convert.ToInt32(coordinates[3]), Convert.ToInt32(coordinates[4])] = tmp;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            commands = Console.ReadLine();
        }
    }
}
