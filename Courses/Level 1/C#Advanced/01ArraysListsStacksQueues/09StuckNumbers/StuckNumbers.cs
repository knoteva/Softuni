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
        //string[] nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        bool match = false;
        for (int i1 = 0; i1 < nums.Length; i1++)
        {
            for (int i2 = 0; i2 < nums.Length; i2++)
            {
                for (int i3 = 0; i3 < nums.Length; i3++)
                {
                    for (int i4 = 0; i4 < nums.Length; i4++)
                    {
                        string a = nums[i1];
                        string b = nums[i2];
                        string c = nums[i3];
                        string d = nums[i4];
                        if (a != b && a != c && a != d && b != c && b != d && c != d && (a + b).Equals(c + d))
                        {
                                Console.WriteLine(a + "|" + b + "==" + c + "|" + d);
                                match = true;   
                        }
                    }
                }
            }
        }
        if (!match)
        {
            Console.WriteLine("No");
        }
    }
}

