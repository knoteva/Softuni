using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Wild_Farm.Animals.Contacts
{
    public interface IBird
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
    }
}
