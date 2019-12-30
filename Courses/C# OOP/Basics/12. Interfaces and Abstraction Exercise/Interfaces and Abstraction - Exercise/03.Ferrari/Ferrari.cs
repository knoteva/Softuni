using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
    public class Ferrari : ICar
    {

        public Ferrari(string driver)
        {
            Driver = driver;
        }

        public string Model => "488-Spider";

        public string Driver { get; set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }
        public override string ToString()
        {
            return $"{Model}/{Brakes()}/{Gas()}/{Driver}";
        }
    }
}
