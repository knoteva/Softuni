using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari.Core
{
    public class Engine
    {
        public void Run()
        {
            string name = Console.ReadLine();
            var car = new Ferrari(name);
            Console.WriteLine(car.ToString());
        }
    }
}
