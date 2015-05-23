using System;
using System.Collections.Generic;
using System.Linq;

class SieveOfEratosthenes
{  
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var prime = Enumerable.Range(0, n + 1).ToList();
        prime[0] = - 1;
        prime[1] = - 1;
        for (int i = 2; i < prime.Count; i++)
        {
            for (int j = i * 2; j < prime.Count; j = j + i)
            {
               prime[j] = -1;
            }
        }
        prime.RemoveAll(x => x < 0);
        Console.WriteLine(string.Join(", ", prime));

        //TIME LIMIT 1

        //int n = int.Parse(Console.ReadLine());
        //var noPrime = new List<int>();
        //var prime = new List<int>();

        //for (int i = 2; i <= n; i++)
        //{
        //    for (int j = i * 2; j <= n; j = j + i)
        //    {
        //        if (!noPrime.Contains(j))
        //        {
        //            noPrime.Add(j);
        //        }
        //    }
        //}

        //for (int i = 2; i <= n; i++)
        //{
        //    if (!noPrime.Contains(i))
        //    {
        //        prime.Add(i);
        //    }
        //}
        //Console.WriteLine(string.Join(", ", prime));

        //TIME LIMIT 2

        //int n = int.Parse(Console.ReadLine());
        //var prime = Enumerable.Range(2, n - 1).ToList();

        //for (int i = 2; i <= n; i++)
        //{
        //    for (int j = i * 2; j <= n; j = j + i)
        //    {
        //        if (prime.Contains(j))
        //        {
        //            prime.Remove(j);
        //        }
        //    }
        //}
        //Console.WriteLine(string.Join(", ", prime));
    }
}