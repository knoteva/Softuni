using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine()
                .Split(' ')
                .ToList();
            var arr2 = Console.ReadLine()
                .Split(' ')
                .ToList();
            var listCommon = arr2.Intersect(arr1);
            Console.WriteLine(string.Join(" ", listCommon));
        }
    }
}
