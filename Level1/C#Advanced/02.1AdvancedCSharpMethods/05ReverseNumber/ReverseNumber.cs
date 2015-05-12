using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseNumber
{
    static void Main()
    {
        double num = double.Parse(Console.ReadLine());
        double reversed = GetReversedNumber(num);
        Console.WriteLine(reversed);
    }

    public static double GetReversedNumber(double num)
    {
        string reverse = string.Join("", num.ToString().Reverse().ToArray());
        return Convert.ToDouble(reverse);
    }
}

