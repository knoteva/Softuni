using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class LettersChangeNumbers
{
    private static void Main()
    {
        string[] input = Regex.Split(Console.ReadLine(), "\\s+").Where(x => !string.IsNullOrEmpty(x)).ToArray();
        double sum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            string word = input[i];
            double num = Convert.ToDouble(word.Substring(1, word.Length - 2));
            char firstCh = word[0];
            char secondCh = word[word.Length - 1];
            num = FirstChar(firstCh, num);
            num = NextChar(secondCh, num);
            sum += num;
        }
        Console.WriteLine("{0:F2}", sum);
    }

    private static double FirstChar(char c, double number)
    {
        if (c >= 65 && c <= 90)
        {
            return number / (c - 64);
        }
        return number * (c - 96);
    }

    private static double NextChar(char c, double number)
    {
        if (c >= 65 && c <= 90)
        {
            return number - (c - 64);
        }
        return number + (c - 96);
    }
}

