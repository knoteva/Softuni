using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PythagoreanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] nums = new int[n];
        bool noMatch = true;

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        for (int i1 = 0; i1 < n; i1++)
        {
            for (int i2 = 0; i2 < n; i2++)
            {
                for (int i3 = 0; i3 < n; i3++)
                {
                    int a = nums[i1];
                    int b = nums[i2];
                    int c = nums[i3];
                    if (a <= b && a * a + b * b == c * c)
                    {
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", a, b, c);
                        noMatch = false;
                    }
                }
            }
        }
        if (noMatch)
        {
            Console.WriteLine("No");
        }

    }
}

