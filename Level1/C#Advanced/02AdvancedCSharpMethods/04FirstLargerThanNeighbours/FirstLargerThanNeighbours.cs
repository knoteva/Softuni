using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] seqOne = { 1, 3, 4, 5, 1, 0, 5 };
        int[] seqTwo = { 1, 2, 3, 4, 5, 6, 6 };
        int[] seqThree = { 1, 1, 1 };
        Console.WriteLine(GetIndexOfFirstLarger(seqOne));
        Console.WriteLine(GetIndexOfFirstLarger(seqTwo));
        Console.WriteLine(GetIndexOfFirstLarger(seqThree));
    }

    private static int GetIndexOfFirstLarger(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i != 0 && i != arr.Length - 1)
            {
                if (arr[i] > arr[i - 1] &&
                    arr[i] > arr[i + 1])
                {
                    return i;
                }
                if (i == 0 && arr[i] > arr[i + 1])
                {
                    return i;
                }
            }
        }
        return -1;
    }
}

