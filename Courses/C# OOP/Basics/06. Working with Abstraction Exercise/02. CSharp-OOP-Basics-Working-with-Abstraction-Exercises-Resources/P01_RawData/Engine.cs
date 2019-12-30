using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Engine
    {
        private int speed;
        private int power;     

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get => speed; set => speed = value; }
        public int Power { get => power; set => power = value; }
    }
}
