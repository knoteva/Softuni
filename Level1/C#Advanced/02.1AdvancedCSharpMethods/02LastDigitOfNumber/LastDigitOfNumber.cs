using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class LastDigitOfNumber
{
    private static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine(GetLastDigitAsWord(num));
    }

    //private static string GetLastDigitAsWord(int num)
    //{
    //    string[] number = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    //    int lastDigit = num % 10;
    //    return number[lastDigit];
    //}

    private static string GetLastDigitAsWord(int num)
    {
        int lastDigit = num % 10;
        string wordDigit = "";
        switch (lastDigit)
        {
            case 0:
                wordDigit = "zero";
                break;
            case 1:
                wordDigit = "one";
                break;
            case 2:
                wordDigit = "two";
                break;
            case 3:
                wordDigit = "three";
                break;
            case 4:
                wordDigit = "four";
                break;
            case 5:
                wordDigit = "five";
                break;
            case 6:
                wordDigit = "six";
                break;
            case 7:
                wordDigit = "seven";
                break;
            case 8:
                wordDigit = "eight";
                break;
            case 9:
                wordDigit = "nine";
                break;
        }
        return wordDigit;
    }
}

