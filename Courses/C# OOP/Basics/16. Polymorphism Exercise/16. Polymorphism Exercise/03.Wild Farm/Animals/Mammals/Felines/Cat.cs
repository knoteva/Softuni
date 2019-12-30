using System;
using System.Collections.Generic;
using System.Text;
using _03.Wild_Farm.Foods;

namespace _03.Wild_Farm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double increasingWeight = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                Weight += food.Quantity * increasingWeight;
                FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
