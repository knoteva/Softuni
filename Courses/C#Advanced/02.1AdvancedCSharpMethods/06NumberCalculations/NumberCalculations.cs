using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumberCalculations
{
    static void Main()
    {
        double[] doubleNums = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        //decimal[] decimalNums = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
        Console.WriteLine(GetMin(doubleNums));
        //Console.WriteLine(GetMin(decimalNums));
        Console.WriteLine(GetMax(doubleNums));
        //Console.WriteLine(GetMax(decimalNums));
        Console.WriteLine(GetAverage(doubleNums));
        //Console.WriteLine(GetAverage(decimalNums));
        Console.WriteLine(GetSum(doubleNums));
        //Console.WriteLine(GetSum(decimalNums));
        Console.WriteLine(GetProduct(doubleNums));
        //Console.WriteLine(GetProduct(decimalNums));
    }
    private static double GetMin(double[] arr)
    {
        double min = double.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }
    private static decimal GetMin(decimal[] arr)
    {
        decimal min = decimal.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }
    private static double GetMax(double[] arr)
    {
        double max = double.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
    private static decimal GetMax(decimal[] arr)
    {
        decimal max = decimal.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
    private static double GetAverage(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum / arr.Length;
    }
    private static decimal GetAverage(decimal[] arr)
    {
        decimal sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum / arr.Length;
    }
    private static double GetSum(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }
    private static decimal GetSum(decimal[] arr)
    {
        decimal sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }
    private static double GetProduct(double[] arr)
    {
        double product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }
    private static decimal GetProduct(decimal[] arr)
    {
        decimal product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }
}

