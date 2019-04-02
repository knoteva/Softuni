using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitCarousel
{
    static void Main()
    {   
        //
        int number = byte.Parse(Console.ReadLine());
        int rotations = byte.Parse(Console.ReadLine());

        for (int i = 0; i < rotations; i++)
        {
            string direction = Console.ReadLine();

            if (direction == "right")
            {
                int rightMostBit = number & 1;
                number >>= 1;
                //
                number |= (byte)(rightMostBit << 5);
            }
            else if (direction == "left")
            {
                //
                int leftMostBit = (number >> 5) & 1;
                number <<= 1;
                number |= (byte)leftMostBit;
                number &= ~(1 << 6);
            }
        }

        Console.WriteLine(number);
    }
}

