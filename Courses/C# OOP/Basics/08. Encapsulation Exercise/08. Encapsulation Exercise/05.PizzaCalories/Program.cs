namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaName = Console.ReadLine().Split();

            string[] doughInfo = Console.ReadLine().Split();

            try
            {
                
                Dough dough = new Dough(doughInfo[1], doughInfo[2], int.Parse(doughInfo[3]));

                Pizza pizza = new Pizza(pizzaName[1])
                {
                    Dough = dough
                };

                while (true)
                {
                    string[] toppingInfo = Console.ReadLine().Split();

                    if (toppingInfo[0] == "END")
                    {
                        break;
                    }

                    Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
