using _07.FoodShortage.Creatures;
using _07.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.FoodShortage.Core
{
    public class Engine
    {
        public void Run()
        {
            var buyers = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthdate = input[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    buyers.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    string group = input[2];

                    Rebel rebel = new Rebel(name, age, group);

                    buyers.Add(rebel);
                }
            }

            string buyerName;
            while ((buyerName = Console.ReadLine()) != "End")
            {
                Person buyer = buyers.FirstOrDefault(b => b.Name == buyerName);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            double totalFoodAmount = buyers.Sum(b => b.Food);

            Console.WriteLine(totalFoodAmount);

        }
    }
}
