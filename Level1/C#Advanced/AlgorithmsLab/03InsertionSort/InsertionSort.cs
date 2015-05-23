using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class InsertionSort
{
    static void Main()
    {
        var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
        for (int i = 1; i < nums.Count; i++)
        {
            var temp = nums[i];
            var prev = i - 1;

            while (prev >= 0 && nums[prev] > temp)
            {
                nums[prev + 1] = nums[prev];
                prev--;
            }

            nums[prev + 1] = temp;
        }
        Console.WriteLine(string.Join(" ", nums));
    }
}

