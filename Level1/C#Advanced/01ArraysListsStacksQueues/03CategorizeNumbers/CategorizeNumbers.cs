using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CategorizeNumbers
{
    static void Main(string[] args)
    {
        double[] input = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
        List<int> roundNums = new List<int>();
        List<double> floatNums= new List<double>();      
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] % 1 == 0)
            {
                roundNums.Add(Convert.ToInt32(input[i]));
            }
            else if (input[i] % 1 != 0)
            {
                floatNums.Add(input[i]);
            }
        }
        Console.WriteLine("[" + string.Join(" ", floatNums) + "]" + " -> " + "min: " + floatNums.Min() + ", max: " + floatNums.Max() + ", sum: " + floatNums.Sum() + ", avg: " + "{0:F2}", floatNums.Average());
        Console.WriteLine();
        Console.WriteLine("[" + string.Join(" ", roundNums) + "]" + " -> " + "min: " + roundNums.Min() + ", max: " + roundNums.Max() + ", sum: " + roundNums.Sum() + ", avg: " + "{0:F2}", roundNums.Average());
        Console.WriteLine();
    }
}

