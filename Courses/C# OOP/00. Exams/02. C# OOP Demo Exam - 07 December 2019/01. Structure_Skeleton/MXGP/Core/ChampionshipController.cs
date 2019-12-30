using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly MotorcycleRepository motorcycleRepository;
        private readonly RaceRepository raceRepository;
        private readonly RiderRepository riderRepository;

        public ChampionshipController()
        {
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
            this.riderRepository = new RiderRepository();

        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riderRepository.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            var motorcycle = motorcycleRepository.GetByName(motorcycleModel);
            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }
            //rider.AddMotorcycle(motorcycle);
            //riderRepository.Add(rider);
            riderRepository.GetByName(riderName).AddMotorcycle(motorcycleRepository.GetByName(motorcycleModel));
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var rider = riderRepository.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            //race.AddRider(rider);
            //raceRepository.Add(race);
            raceRepository.GetByName(raceName).AddRider(riderRepository.GetByName(riderName));
            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var text = "";
            if (type == "Speed")
            {
                var motorcycle = new SpeedMotorcycle(model, horsePower);
                if (motorcycleRepository.GetByName(model) != null)
                {
                    throw new ArgumentException($"Motorcycle {model} is already created.");
                }
                motorcycleRepository.Add(motorcycle);
                text = "SpeedMotorcycle";
            }
            else if (type == "Power")
            {
                var motorcycle = new PowerMotorcycle(model, horsePower);
                if (motorcycleRepository.GetByName(model) != null)
                {
                    throw new ArgumentException($"Motorcycle {model} is already created.");
                }
                motorcycleRepository.Add(motorcycle);
                text = "PowerMotorcycle";
            }

            return $"{text} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = new Race(name, laps);
            if (raceRepository.GetByName(name) != null)
            {
                throw new ArgumentException($"Race {name} is already created.");
            }
            raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            var rider = new Rider(riderName);
            if (riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }
            riderRepository.Add(rider);
            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            IRace race = raceRepository.GetByName(raceName);
            List<IRider> bestRiders = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(raceRepository.GetByName(raceName).Laps)).ToList();
            if (bestRiders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            StringBuilder sb = new StringBuilder();
            bestRiders[0].WinRace();
            sb.AppendLine($"Rider {bestRiders.ElementAt(0).Name} wins {raceRepository.GetByName(raceName).Name} race.")
                .AppendLine($"Rider {bestRiders.ElementAt(1).Name} is second in {raceRepository.GetByName(raceName).Name} race.")
                .AppendLine($"Rider {bestRiders.ElementAt(2).Name} is third in {raceRepository.GetByName(raceName).Name} race.");

            raceRepository.Remove(raceRepository.GetByName(raceName));

            return sb.ToString().TrimEnd();
        }
    }
}

