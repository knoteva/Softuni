using System;
using System.Collections.Generic;
using System.Text;

class SeriesOfLetters
{
    static void Main()
    {
        string text = Console.ReadLine();

        StringBuilder result = new StringBuilder();

        for (int i = 1; i < text.Length; i++)
        {
            char currentLetter = text[i - 1];
            char nextLetter = text[i];

            if (currentLetter != nextLetter)
            {
                result.Append(currentLetter);
            }
            if (i == text.Length - 1)
            {
                result.Append(nextLetter);
            }
        }
        Console.WriteLine(result);
    }
}