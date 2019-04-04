using System;
using System.Collections.Generic;
using System.Linq;

public class SumAdjacentEqualNumbers
{
    public static void Main()
    {
        List<double> numbers = new List<double>();
        string input = Console.ReadLine();
        List<string> list = input.Split(' ').ToList();
        for (int i = 0; i < list.Count; i++)
        {
            numbers.Add(double.Parse(list[i]));
        }
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            while (i < numbers.Count - 1)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    numbers[i] = numbers[i] + numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    if (i > 0) // връщаме брояча с една позиция, защото като премахнем елемент, трябва да проверяваме и следващия
                    {
                        i--;
                    }
                }
                else
                {
                    i++;
                }

            }

        }



        Console.WriteLine(string.Join(" ", numbers));
    }
}