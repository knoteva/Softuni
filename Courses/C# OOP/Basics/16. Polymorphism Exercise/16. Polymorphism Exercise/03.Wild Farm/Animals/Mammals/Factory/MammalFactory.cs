using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Wild_Farm.Animals.Mammals.Factory
{
    class MammalFactory
    {
        public Mammal CreateMammal(string type, string name, double weight, string livingRegion)
        {
            type = type.ToLower();

            switch (type)
            {
                case "dog":
                    return new Dog(name, weight, livingRegion);
                case "mouse":
                    return new Mouse(name, weight, livingRegion);
                default:
                    return null;
            }
        }
    }
}
