using System;
using System.Collections.Generic;
using System.Text;
using _03.Wild_Farm.Foods;

namespace _03.Wild_Farm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double increasingWeight = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
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
            Console.WriteLine("Squeak");
        }
        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
