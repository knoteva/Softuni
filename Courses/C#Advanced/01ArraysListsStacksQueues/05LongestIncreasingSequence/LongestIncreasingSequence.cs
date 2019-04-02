using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LongestIncreasingSequence
{
    static void Main()
    {
        // ReSharper disable once PossibleNullReferenceException
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        //int[] inut = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        List<int> nums = new List<int>();
        int maxLength = 0;
        string longNums = "";
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i - 1] < input[i])
            {
                nums.Add(input[i - 1]);
            }
            else
            {
                nums.Add(input[i - 1]);
                if (nums.Count > maxLength)
                {
                    maxLength = nums.Count;
                    longNums = String.Join(", ", nums);
                }
                Console.WriteLine(String.Join(" ", nums));
                nums.Clear();
            }
        }
        nums.Add(input[input.Length - 1]);
        if (nums.Count > maxLength)
        {
            longNums = String.Join(" ", nums);
        }
        Console.WriteLine(String.Join(" ", nums));
        Console.WriteLine("Longest: {0}", String.Join(" ", longNums));
    }
}

