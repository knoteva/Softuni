using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CouplesFrequency
{
    static void Main()
    {
        string[] nums = Console.ReadLine().Split(' ');
        var result = new Dictionary<string, int>();
        double allNums = nums.Length - 1;

        for (int i = 1; i < nums.Length; i++)
        {
            string couple = nums[i - 1] + " " + nums[i];
                if (!result.ContainsKey(couple))
                {
                    result.Add(couple, 0);
                }
            result[couple]++;

        }
        foreach (var fr in result)
        {
            double frequency = fr.Value / allNums * 100;
            Console.WriteLine("{0} -> {1:F2}%", fr.Key, frequency);
        }
        
    }
}

