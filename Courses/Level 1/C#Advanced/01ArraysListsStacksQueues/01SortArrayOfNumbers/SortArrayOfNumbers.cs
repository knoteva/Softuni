using System;


class SortArrayOfNumbers 
{
    static void Main()
    {        
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Array.Sort(input);
        //foreach (var num in input)
        //{
        //    Console.Write("{0} ", num);
        //}
        //Console.WriteLine();
        Console.WriteLine(string.Join(" ", input));
    }
}  

