using Cars.Cars;
using Cars.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Core
{
    public class Engine
    {
        public void Run()
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(tesla.ToString());

        }

    }
}
