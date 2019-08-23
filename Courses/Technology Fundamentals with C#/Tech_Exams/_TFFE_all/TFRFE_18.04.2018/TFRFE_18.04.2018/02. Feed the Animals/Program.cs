using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidUsername
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var animals = new Dictionary<string, int>();
            var hungryAnimalsArea = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "Last Info")
            {
                string command = input.Split(":")[0];

                string name = input.Split(":")[1];
                string area = input.Split(":")[3];

                if (command == "Add")
                {
                    int dailyFoodLimit = int.Parse(input.Split(":")[2]);
                    if (!animals.ContainsKey(name))
                    {
                        animals.Add(name, 0);
                        if (!hungryAnimalsArea.ContainsKey(area))
                        {
                            hungryAnimalsArea.Add(area, 0);
                        }
                        hungryAnimalsArea[area]++;
                    }
                    animals[name] += dailyFoodLimit;

                }
                else
                {
                    int food = int.Parse(input.Split(":")[2]);
                    if (animals.ContainsKey(name))
                    {
                        animals[name] -= food;
                        if (animals[name] <= 0)
                        {
                            Console.WriteLine($"{name} was successfully fed");
                            animals.Remove(name);
                            hungryAnimalsArea[area]--;
                        }
                    }
                }
            }

            Console.WriteLine($"Animals:");
            foreach (var animal in animals.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{animal.Key} -> {animal.Value}g");
            }
            Console.WriteLine($"Areas with hungry animals:");
            foreach (var area in hungryAnimalsArea.Where(x => x.Value > 0).OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{area.Key} : {area.Value}");
            }
            
        }
    }
}