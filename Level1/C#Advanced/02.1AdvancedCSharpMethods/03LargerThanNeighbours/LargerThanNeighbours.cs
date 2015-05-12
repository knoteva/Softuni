using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

class LargerThanNeighbours
{
    private static bool IsLargerThanNeighbours(int[] arr, int i)
    {
        if (i != 0 && i != arr.Length - 1)
        {
            if (arr[i] > arr[i + 1] &&
                arr[i] > arr[i - 1])
            {
                return true;
            }
        }

        if (i == 0 && arr[i] > arr[i + 1])
        {
            return true;
        }

        if (i == arr.Length - 1 && arr[i] > arr[i - 1])
        {
            return true;
        }

        return false;
    }

    static void Main()
    {
        int[] numbers = {1, 3, 4, 5, 1, 0, 5};
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }
}

