using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

class LabyrinthDash
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var matrix = new List<char[]>();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            matrix.Add(line.ToCharArray());
        }
        string commands = Console.ReadLine();
        int lives = 3;
        int movesMade = 0;
        int row = 0;
        int col = 0;

        foreach (var direction in commands)
        {
            int previousRow = row;
            int previousCol = col;
            switch (direction)
            {
                case '<':
                    col--;
                    break;
                case '>':
                    col++;
                    break;
                case 'v':
                    row++;
                    break;
                case '^':
                    row--;
                    break;
            }
            if (!IsCellIsideMatrix(row, col, matrix) || matrix[row][col] == ' ')
            {
                Console.WriteLine("Fell off a cliff! Game Over!");
                movesMade++;
                break;
            }
            else if (matrix[row][col] == '_' || matrix[row][col] == '|')
            {
                Console.WriteLine("Bumped a wall.");
                row = previousRow;
                col = previousCol;
            }
            else if (matrix[row][col] == '@' || matrix[row][col] == '*' || matrix[row][col] == '#')
            {
                lives--;
                Console.WriteLine("Ouch! That hurt! Lives left: {0}",lives);
                movesMade++;
                if (lives == 0)
                {
                    Console.WriteLine("No lives left! Game Over!");
                    break;
                }
            }
            else if (matrix[row][col] == '$')
            {
                lives++;
                movesMade++;
                matrix[row][col] = '.';
                Console.WriteLine("Awesome! Lives left: {0}", lives);
            }
            else
            {
                movesMade++;
                Console.WriteLine("Made a move!");
            }
        }
        Console.WriteLine("Total moves made: {0}", movesMade);
    }

    private static bool IsCellIsideMatrix(int row, int col, List<char[]> matrix)
    {
        bool isRowInsideMatrix = 0 <= row && row < matrix.Count;

        if (!isRowInsideMatrix)
        {
            return false;
        }

        bool isColInRange = 0 <= col && col < matrix[row].Length;

        return isColInRange;
    }
}

