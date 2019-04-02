namespace SandBox
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {

            long triangleRows = long.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[triangleRows][];

            jaggedArray[0] = new long[1];
            jaggedArray[0][0] = 1;


            for (long row = 1; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new long[row + 1];
                jaggedArray[row][0] = 1;
                jaggedArray[row][jaggedArray[row].Length - 1] = 1;

                for (long col = 1; col < jaggedArray[row].Length - 1; col++)
                {
                    long leftDiagonal = jaggedArray[row - 1][col - 1];
                    long rightDiagonal = jaggedArray[row - 1][col];

                    jaggedArray[row][col] = leftDiagonal + rightDiagonal;
                }
            }

            for (long row = 0; row < triangleRows; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }
    }
}