using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class MaximalSum
{
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //int[] size = Regex.Split(Console.ReadLine(), "\\s+").Select(int.Parse).ToArray();
        var matrix = new List<List<int>>();
        int rows = size[0];
        int cols = size[1];
        //Fill matrix;
        for (int i = 0; i < rows; i++)
        {
            matrix.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
        }
        int maxSum = int.MinValue;
        int currSum = 0;
        int[,] maxMatrix = new int[3, 3];
        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                currSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] + matrix[row + 1][col] +
                          matrix[row + 1][col + 1] + matrix[row + 1][col + 2] + matrix[row + 2][col] + matrix[row + 2][col + 1] +
                          matrix[row + 2][col + 2];
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            maxMatrix[i, j] = matrix[row + i][col + j];
                        }
                    }
                }
            }
        }
        Console.WriteLine("Sum = {0}", maxSum);
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write("{0,2} ", maxMatrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

    