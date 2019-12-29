using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < line.Length; i += 2)
            {
                string type = line[i];
                long quantity = long.Parse(line[i + 1]);

                string item = string.Empty;

                if (type.Length == 3)
                {
                    item = "Cash";
                }
                else if (type.ToLower().EndsWith("gem"))
                {
                    item = "Gem";
                }
                else if (type.ToLower() == "gold")
                {
                    item = "Gold";
                }

                if (item == "")
                {
                    continue;
                }
                else if (capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                {
                    continue;
                }

               //switch (item)
                //{
                //    case "Gem":
                //        if (!bag.ContainsKey(item))
                //        {
                //            if (bag.ContainsKey("Gold"))
                //            {
                //                if (quantity > bag["Gold"].Values.Sum())
                //                {
                //                    continue;
                //                }
                //            }
                //            else
                //            {
                //                continue;
                //            }
                //        }
                //        else if (bag[item].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                //        {
                //            continue;
                //        }
                //        break;
                //    case "Cash":
                //        if (!bag.ContainsKey(item))
                //        {
                //            if (bag.ContainsKey("Gem"))
                //            {
                //                if (quantity > bag["Gem"].Values.Sum())
                //                {
                //                    continue;
                //                }
                //            }
                //            else
                //            {
                //                continue;
                //            }
                //        }
                //        else if (bag[item].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                //        {
                //            continue;
                //        }
                //        break;
                //}

                if (!bag.ContainsKey(item))
                {
                    bag[item] = new Dictionary<string, long>();
                }
                if (item == "Gold")
                {
                    gold += quantity;
                }
                else if (item == "Gem")
                {
                    gems += quantity;
                }
                else if (item == "Cash")
                {
                    money += quantity;
                }
                if (!bag[item].ContainsKey(type))
                {
                    bag[item][type] = 0;
                }

                bag[item][type] += quantity;
                
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}