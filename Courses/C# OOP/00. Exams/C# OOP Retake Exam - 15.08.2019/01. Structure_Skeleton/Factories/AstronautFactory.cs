using SpaceStation.Models.Astronauts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Factories
{
    public class AstronautFactory
    {
        public Astronaut CreateAstronaut(string type, string astronautName)
        {
    
            switch (type)
            {
                case "Biologist":
                    return new Biologist(astronautName);
                case "Geodesist":
                    return new Geodesist(astronautName);
                case "Meteorologist":
                    return new Meteorologist(astronautName);
                default:
                    throw new InvalidOperationException($"Astronaut type doesn't exists!");
            }
        }
    }
}
