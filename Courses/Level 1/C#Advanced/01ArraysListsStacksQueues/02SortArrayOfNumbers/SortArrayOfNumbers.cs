using System;

class SortArrayOfNumbers
{
    static void Main()
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int temp = 0;

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i + 1; j < input.Length; j++)
            {
                if (input[i] > input[j])
                {
                    temp = input[j];
                    input[j] = input[i];
                    input[i] = temp;
                 }         
            }
        }
        Console.WriteLine(string.Join(" ", input));   
    }
}

