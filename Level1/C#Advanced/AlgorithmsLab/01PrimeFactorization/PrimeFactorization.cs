using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrimeFactorization
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b;
        var result = new List<int>();
        int num = a;
        for (b = 2; a > 1; b++)
            if (a % b == 0)
            {
                while (a % b == 0)
                {
                    a /= b;
                    result.Add(b);
                }
            }
        Console.WriteLine("{0} = {1}", num, string.Join(" * ", result));
    }
}

