using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StuckNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] nums = Console.ReadLine().Trim().Split(' ');
        bool noMatch = true;

        for (int i1 = 0; i1 < n; i1++)
        {
            for (int i2 = 0; i2 < n; i2++)
            {
                for (int i3 = 0; i3 < n; i3++)
                {
                    for (int i4 = 0; i4 < n; i4++)
                    {
                        string a = nums[i1];
                        string b = nums[i2];
                        string c = nums[i3];
                        string d = nums[i4];
                        if (a != b && a != c && a!= d && b != c && b != d && c != d && a + b == c + d)
                        {
                            noMatch = false;
                            Console.WriteLine("{0}|{1}=={2}|{3}", a, b, c, d);
                        }
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

