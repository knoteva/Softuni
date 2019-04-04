using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int sum = 0;
            int removedElement = 0;

            while (!sequence.Count.Equals(0))
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    removedElement = sequence[0];
                    sum += removedElement;
                    sequence[0] = sequence[sequence.Count - 1];

                    IncreaseAndDecrease(sequence, removedElement);
                }
                else if (index >= sequence.Count)
                {
                    removedElement = sequence[sequence.Count - 1];
                    sum += removedElement;
                    sequence[sequence.Count - 1] = sequence[0];

                    IncreaseAndDecrease(sequence, removedElement);
                }
                else
                {
                    removedElement = sequence[index];
                    sum += removedElement;
                    sequence.RemoveAt(index);

                    IncreaseAndDecrease(sequence, removedElement);
                }
            }

            Console.WriteLine(sum);
        }

        private static List<int> IncreaseAndDecrease(List<int> sequence, int removedElement)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] <= removedElement)
                {
                    sequence[i] += removedElement;
                }
                else if (sequence[i] > removedElement)
                {
                    sequence[i] -= removedElement;
                }
            }

            return sequence;
        }
    }
}