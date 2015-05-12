using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class StringMatrixRotation
{
    private static void Main()
    {
        //read degrees
        int rotate = Convert.ToInt32(Regex.Replace(Console.ReadLine(), @"[^\d]", "")) % 360;
        var matrix = new List<List<char>>();
        string firstLine = Console.ReadLine();
        int maxSize = 0;

        //read matrix
        while (firstLine != "END")
        {
            matrix.Add(firstLine.ToList());
            int currSize = firstLine.Length;
            if (currSize > maxSize)
            {
                maxSize = currSize;
            }
            firstLine = Console.ReadLine();
        }

        //fill
        foreach (var row in matrix)
        {
            if (row.Count < maxSize)
            {
                while (row.Count < maxSize)
                {
                    row.Add(' ');
                }
            }
        }

        //rotate
        int rotations = rotate / 90;
        for (int i = 0; i < rotations; i++)
        {
            matrix = RotateMatrix(matrix);
        }

        //print
        foreach (var a in matrix)
        {
            Console.WriteLine(string.Join("", a));
        }
    }

    private static List<List<char>> RotateMatrix(List<List<char>> matrix)
    {
        var result = new List<List<char>>();
        int row = 0;
        for (int i = 0; i < matrix[0].Count; i++)
        {
            result.Add(new List<char>());
            for (int j = matrix.Count - 1; j >= 0; j--)
            {
                result[row].Add(matrix[j][i]);
            }
            row++;
        }
        return result;
    }
}


