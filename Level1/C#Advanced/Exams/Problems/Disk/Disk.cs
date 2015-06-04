using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Disk
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int radius = int.Parse(Console.ReadLine());
        int x = size / 2;
        int y = size/2;


        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                bool inside = (col - x)*(col - x) + (row - y)*(row - y) <= radius*radius;
                if (inside)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
                
            }
            Console.WriteLine();
        }
    }
}

