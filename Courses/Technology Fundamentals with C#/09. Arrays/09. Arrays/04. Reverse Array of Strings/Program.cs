using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split().ToArray();
            Array.Reverse(nums);
            foreach (string value in nums)
            {
                Console.Write(value + " ");
            }
        }
    }
}
