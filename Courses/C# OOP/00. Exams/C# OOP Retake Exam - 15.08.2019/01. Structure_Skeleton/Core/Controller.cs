using SpaceStation.Core.Contracts;
using SpaceStation.Factories;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautRepository astronautRepository;
        private readonly PlanetRepository planetRepository;
        private readonly IMission mission;
        private readonly AstronautFactory astronautFactory;
        private int exploredPlanetsCount;

        public Controller()
        {
            astronautRepository = new AstronautRepository();
            planetRepository = new PlanetRepository();
            mission = new Mission();
            astronautFactory = new AstronautFactory();
            exploredPlanetsCount = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            var astronaut = this.astronautFactory.CreateAstronaut(type, astronautName);
            astronautRepository.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);

            planet.AddItems(items);

            planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronauts = astronautRepository
                .Models
                .Where(a => a.Oxygen > 60)
                .ToList();

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException($"You need at least one astronaut to explore the planet");
            }
            IPlanet planet = planetRepository.FindByName(planetName);
            mission.Explore(planet, astronauts);
            exploredPlanetsCount++;

            return $"Planet: {planet.Name} was explored! Exploration finished with {astronauts.Where(a => a.CanBreath == false).Count()} dead astronauts!";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!")
                .AppendLine($"Astronauts info:");
            foreach (var astronaut in astronautRepository.Models)
            {
                var items = astronaut.Bag.Items.Count > 0 ? string.Join(", ", astronaut.Bag.Items) : "none";
                sb.AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}")
                    .AppendLine($"Bag items: {items}");
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (astronautRepository.FindByName(astronautName) == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            IAstronaut astronaut = astronautRepository.FindByName(astronautName);
            astronautRepository.Remove(astronaut);

            return string.Format($"Astronaut {astronautName} was retired!");
        }
    }
}
