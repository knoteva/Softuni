using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

class ClearingCommands
{
    static void Main()
    {   
        var matrix = new List<char[]>();

        while (true)
        {
            string line = Console.ReadLine();
            if (line == "END")
            {
                break;
            }
            matrix.Add(line.ToCharArray());
        }

        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                int currRow = 0;
                int currCol = 0;

                switch (matrix[row][col])
                {
                    case '>':
                        currRow = row;
                        currCol = col + 1;
                        while (currCol < matrix[currRow].Length && matrix[currRow][currCol] != '>' && matrix[currRow][currCol] != '<' && matrix[currRow][currCol] != '^' && matrix[currRow][currCol] != 'v')
                        {
                            matrix[currRow][currCol] = ' ';
                            currCol++;
                        }
                        break;
                    case '<':
                        currRow = row;
                        currCol = col - 1;
                        while (currCol >= 0 && matrix[currRow][currCol] != '>' && matrix[currRow][currCol] != '<' && matrix[currRow][currCol] != '^' && matrix[currRow][currCol] != 'v')
                        {
                            matrix[currRow][currCol] = ' ';
                            currCol--;
                        }
                        break;
                    case '^':
                        currRow = row - 1;
                        currCol = col;
                        while (currRow >= 0 && matrix[currRow][currCol] != '>' && matrix[currRow][currCol] != '<' && matrix[currRow][currCol] != '^' && matrix[currRow][currCol] != 'v')
                        {
                            matrix[currRow][currCol] = ' ';
                            currRow--;
                        }
                        break;
                    case 'v':
                        currRow = row + 1;
                        currCol = col;
                        while (currRow < matrix.Count && matrix[currRow][currCol] != '>' && matrix[currRow][currCol] != '<' && matrix[currRow][currCol] != '^' && matrix[currRow][currCol] != 'v')
                        {
                            matrix[currRow][currCol] = ' ';
                            currRow++;
                        }
                        break;
                }
            }
        }


        PrintMatrix(matrix);
    }

    private static void PrintMatrix(List<char[]> matrix ) 
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            Console.WriteLine("<p>{0}</p>", SecurityElement.Escape(new string(matrix[i])));
        }
    }
}

