using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FillTheMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = MatrixA(n);
        PrintMatrix(matrix, n);
        Console.WriteLine();
        matrix = MatrixB(n);
        PrintMatrix(matrix, n);
        Console.WriteLine();
    }

    static int[,] MatrixA(int n)
    {       
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = (i + 1) + j * n;
            }
        }
        return matrix;
    }

    static int[,] MatrixB(int n)
    {
        int[,] matrix = new int[n, n];
        matrix[0, 0] = 1;
        for (int i = 1; i < n; i++)
        {
            if (i % 2 == 1)
            {
                matrix[0, i] = matrix[0, i - 1] + n * 2 - 1;
            }
            else
            {
                matrix[0, i] = matrix[0, i - 1] + 1;
            }
        }
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j % 2 == 1)
                {
                    matrix[i, j] = matrix[i - 1, j] - 1;
                }
                else
                {
                    matrix[i, j] = matrix[i - 1, j] + 1;
                }
            }
        }
        return matrix;
    }

    private static void PrintMatrix(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0, 4}", matrix[i, j]);
                Console.Write("|");                
            }
            Console.WriteLine();
        }
    }
}

