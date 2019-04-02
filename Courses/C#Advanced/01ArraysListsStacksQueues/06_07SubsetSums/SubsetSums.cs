using System;
using System.Collections.Generic;
using System.Linq;


class SubsetSums
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        List<int> input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).Distinct().ToList();

        List<List<int>> allLists = combinations(input, sum);
        allLists = sort(allLists);
        if (allLists.Count == 0)
        {
            Console.WriteLine("No matching subsets.");
        }
        foreach (var item in allLists)
        {
            Console.WriteLine("{0} = {1}", string.Join(" + ", item), sum);
        }

    }
    private static List<List<int>> combinations(List<int> list, int neededSum)
    {
       
        List<List<int>> allLists = new List<List<int>>();
        List<int> currList = new List<int>();
        double count = Math.Pow(2, list.Count);
        for (int i = 1; i <= count - 1; i++)
        {
            string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == '1')
                {
                    currList.Add(list[j]);
                }
            }

            if (currList.Sum() == neededSum)
            {
                allLists.Add(new List<int>(currList));
            }

            currList.Clear();
        }

        return allLists;
    }

    private static List<List<int>> sort(List<List<int>> list)
    {
        list.Sort((x, y) =>
        {
            x.Sort();
            y.Sort();
            if (x.Count == y.Count)
            {
                return x[0] - y[0];
            }

            return x.Count - y.Count;

        });

        return list;
    }
}
