using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class MatrixShuffle
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        char[,] matrix = new char[size, size];
        int realSize = size;
        int x = 0;
        int y = 0;
        int index = 0;
        string sentence = "";
        while (size > 0)
        {
            for (int i = y; i <= y + size - 1 && index <= text.Length - 1; i++)
            {
                
                matrix[x, i] = text[index];
                index++;
            }

            for (int j = x + 1; j <= x + size - 1 && index <= text.Length - 1; j++)
            {
                matrix[j, y + size - 1] = text[index];
                index++;
            }

            for (int i = y + size - 2; i >= y && index <= text.Length - 1; i--)
            {
                matrix[x + size - 1, i] = text[index];
                index++;
            }

            for (int i = x + size - 2; i >= x + 1 && index <= text.Length - 1; i--)
            {
                matrix[i, y] = text[index];
                index++;
            }
            x = x + 1;
            y = y + 1;
            size = size - 2;
        }
        for (int i = 0; i < realSize; i++)
        {

            for (int j = i % 2 == 0 ? 0 : 1; j < realSize; j += 2)
            {
                sentence += matrix[i, j];
            }
        }
        for (int i = 0; i < realSize; i++)
        {
            for (int j = i % 2 == 0 ? 1 : 0; j < realSize; j += 2)
            {
                sentence += matrix[i, j];
            }
        }

        string reversed = "";
       
        string original = sentence.ToLower();
        string regex = Regex.Replace(original, @"[^a-zA-Z]", "");

        for (int i = regex.Length - 1; i >= 0; i--)
        {
            reversed += regex[i].ToString();
        }

        if (reversed == regex)
        {
            Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", sentence);
        }
        else
        {
            Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", sentence);;
        }
    }
}

