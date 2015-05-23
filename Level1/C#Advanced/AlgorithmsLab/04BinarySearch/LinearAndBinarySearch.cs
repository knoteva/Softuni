using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LinearAndBinarySearch
{
    static void Main()
    {
        var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
        int searchNum = int.Parse(Console.ReadLine());
        Console.WriteLine(LinearSearch(nums, searchNum));
    }

    //private static int BinarySearch(List<int> arr, int smaller, int larger, int value)
    //{        
    //    int middle = smaller + (larger - smaller) / 2;
    //    if (value < arr[0] || value > arr[arr.Count - 1])
    //    {
    //        return -1;
    //    }
    //    if (larger <= smaller)
    //    {
    //        return middle;
    //    }
    //    if (value > arr[middle])
    //    {
    //        return BinarySearch(arr, middle + 1, larger, value);
    //    }
    //    return BinarySearch(arr, smaller, middle, value);
    //}

    private static int LinearSearch(List<int> source, int value)
    {
        for (int i = 0; i < source.Count; i++)
        {
            if (source[i] == value)
                return i;
        }
        return -1;
    }
}

