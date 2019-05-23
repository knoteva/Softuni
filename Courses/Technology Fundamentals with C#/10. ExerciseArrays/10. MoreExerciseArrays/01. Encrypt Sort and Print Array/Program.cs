using System;
using System.Collections.Generic;
using System.Linq;

namespace More_Ex_Encrypt_Sort_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] name = new string[n];
            int vowelSum = 0;
            int consonantSum = 0;
            int sum = 0;
            List<int> nums = new List<int>();
            for (int i = 0; i < n; i++)
            {
                name[i] = Console.ReadLine();
                             
            }
            for (int i = 0; i < n; i++)
            {
                

                foreach (var s in name[i])
                {
                    int length = name[i].Length;
                    if (s == 'a' || s == 'e' || s == 'o' || s == 'u' || s == 'i' || s == 'A' || s == 'E' || s == 'O' || s == 'U' || s == 'I')
                    {
                        vowelSum = s * length;
                        sum += vowelSum;
                    }
                    else
                    {
                        consonantSum = s / length;
                        sum += consonantSum;
                    }

                }       
                nums.Add(sum);
                sum = 0;
            }
            nums.Sort();
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
        }
    }
}