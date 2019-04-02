using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            int k = numbers.Count / 4;
            List<int> rowOneLeft = new List<int>();
            List<int> rowOneRight = new List<int>();
            for (int i = 0; i < k; i++)
            {
                rowOneLeft.Add(numbers[i]);
            }
            rowOneLeft.Reverse();
            numbers.Reverse();
            for (int i = 0; i < k; i++)
            {
                rowOneRight.Add(numbers[i]);
            }
            numbers.Reverse();
            List<int> topLine = rowOneLeft.Concat(rowOneRight).ToList();
            int[] result = new int[topLine.Count];
            for (int i = 0; i < topLine.Count; i++)
            {
                result[i] = topLine[i] + numbers[k + i];
            }
            foreach (var item in result)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}