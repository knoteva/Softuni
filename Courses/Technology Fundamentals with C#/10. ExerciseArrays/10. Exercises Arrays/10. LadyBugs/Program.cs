using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugIndex = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr = new int[fieldSize];

            for (int i = 0; i < arr.Length; i++)
            {
                if (ladybugIndex.Contains(i)) arr[i] = 1;
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandToArray = command.Split();
                int index = int.Parse(commandToArray[0]);
                string direction = commandToArray[1];
                int range = int.Parse(commandToArray[2]);

                if ((index >= 0) && (index < fieldSize) && (arr[index] == 1))
                {
                    arr[index] = 0;

                    if (direction == "right")
                    {
                        while ((index + range < fieldSize) && (index + range >= 0))
                        {
                            if (arr[index + range] == 0)
                            {
                                arr[index + range] = 1;
                                break;
                            }
                            else index += range;
                        }
                    }
                    else if (direction == "left")
                    {
                        while ((index - range >= 0) && (index - range < fieldSize))
                        {
                            if (arr[index - range] == 0)
                            {
                                arr[index - range] = 1;
                                break;
                            }
                            else index -= range;
                        }
                    }
                    else arr[index] = 1;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}