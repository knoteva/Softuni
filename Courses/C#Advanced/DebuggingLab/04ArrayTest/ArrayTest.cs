using System.Linq.Expressions;

namespace Arrays
{
    using System;
    using System.Linq;

    public class ArraysMain
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());
            string action = "";
            long[] array = Console.ReadLine() .Split(ArgumentsDelimiter).Select(long.Parse).ToArray();

            string command = Console.ReadLine();
            //
            while (!command.Equals("stop"))
            {
                //
                string line = command.Trim();
                int[] args = new int[2];
                //
                string[] stringParams = line.Split(ArgumentsDelimiter);
                action = stringParams[0];
                if (command.Contains("add") ||
                    //
                    command.Contains("subtract") ||
                    command.Contains("multiply") ||
                    command.Contains("multiply"))

                {
                    //
                    args[0] = int.Parse(stringParams[1]);
                    args[1] = int.Parse(stringParams[2]);

                    PerformAction(array, action, args);
                }
                //
                else
                {
                    PerformAction(array, action, args);
                }
                

                PrintArray(array);
                //
                Console.WriteLine();

                command = Console.ReadLine();
            }
        }

        static void PerformAction(long[] array, string action, int[] args)
        {
            //long[] array = arr.Clone() as long[];
            int pos = args[0] - 1;
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    break;
                case "add":
                    array[pos] += value;
                    break;
                case "subtract":
                    array[pos] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(array);
                    break;
                case "rshift":
                    ArrayShiftRight(array);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            //
            long currentEndElement = array[array.Length - 1];
            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            //
            array[0] = currentEndElement;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            //
            long currentFirstElement = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            //
            array[array.Length - 1] = currentFirstElement;
        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                //
                Console.Write(array[i] + " ");
            }
        }
    }
}
