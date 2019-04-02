﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class PlusRemove
{
    static void Main()
    {
        var matrix = new List<List<char>>();
        var output = new List<List<char>>();
        int maxSize = 0;
        string firstLine = Console.ReadLine();

        //read
        while (firstLine != "END")
        {
            matrix.Add(firstLine.ToList());
            output.Add(firstLine.ToList());
            int currSize = firstLine.Length;

            if (currSize > maxSize)
            {
                maxSize = currSize;
            }
            firstLine = Console.ReadLine();
        }

        for (int i = 0; i < matrix.Count; i++)
        {
            var row = matrix[i];
            if (row.Count < maxSize)
            {
                while (row.Count < maxSize)
                {
                    row.Add('ь');
                    output[i].Add('ь');
                }
            }
        }

        for (int row = 1; row < matrix.Count - 1; row++)
        {
            for (int col = 1; col < maxSize - 1; col++)
            {
                string ch = matrix[row][col].ToString().ToLower();

                if (ch.Equals(matrix[row - 1][col].ToString().ToLower()) &&
                    ch.Equals(matrix[row + 1][col].ToString().ToLower()) &&
                    ch.Equals(matrix[row][col - 1].ToString().ToLower()) &&
                    ch.Equals(matrix[row][col + 1].ToString().ToLower()))
                {
                    output[row][col] = 'ь';
                    output[row][col - 1] = 'ь';
                    output[row][col + 1] = 'ь';
                    output[row - 1][col] = 'ь';
                    output[row + 1][col] = 'ь';
                }
            }
        }

        for (int i = 0; i < output.Count; i++)
        {
            while (output[i].IndexOf('ь') != -1)
            {
                output[i].Remove('ь');
            }
        }

        //print
        foreach (var row in output)
        {
            Console.WriteLine(string.Join("", row));
        }
    }
}

