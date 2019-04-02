using System;

namespace _2._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Reverse(arr);
            foreach (int value in arr)
            {
                Console.Write(value + " ");
            }
          
        }
    }
}
