using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;
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

        //private ICollection<IAquarium> aquariums;
        //private ICollection<IFish> fishes;

        public ChampionshipController()
        {
            motorcycleRepository = new MotorcycleRepository();
            raceRepository = new RaceRepository();
            riderRepository = new RiderRepository();
            //aquariums = new List<IAquarium>();
            //fishes = new List<IFish>();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riderRepository.GetByName(riderName);
            var motorcycle = motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }
            //Gives the Motorcycle with given name to the Rider with given name(if exists).
            //If the Rider does not exist in the RiderRepository, throw InvalidOperationException with message "Rider {name} could not be found."
            //If the Motorcycle does not exist in the MotorcycleRepository, throw InvalidOperationException with message 
            //•	"Motorcycle {name} could not be found."
            //If everything is successful you should add the Motorcycle to the Rider and return the following message:
            //•	"Rider {rider name} received motorcycle {motorcycle name}."
            rider.AddMotorcycle(motorcycle);
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = riderRepository.GetByName(riderName);
            var race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            //Adds a Rider to the Race.
            //If the Race does not exist in the RaceRepository, throw an InvalidOperationException with message: "Race {name} could not be found."
            //If the Rider does not exist in the RiderRepository, throw an InvalidOperationException with message:
            //•	"Rider {name} could not be found."
            //If everything is successful, you should add the Rider to the Race and return the following message:
            //•	"Rider {rider name} added in {race name} race."
            race.AddRider(rider);
            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            Motorcycle motorcycle = null;
            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            else if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            if (motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }
            //Create a Motorcycle with the provided model and horsepower and add it to the repository.There are two types of Motorcycle: "SpeedMotorcycle" and "PowerMotorcycle".
            //If the Motorcycle already exists in the appropriate repository throw an ArgumentException with following message:
            //"Motorcycle {model} is already created."
            //If the Motorcycle is successfully created, the method should return the following message: "{"SpeedMotorcycle"/ "PowerMotorcycle"} {model} is created."
            motorcycleRepository.Add(motorcycle);
            return $"{type}Motorcycle {model} is created.";

        }

        public string CreateRace(string name, int laps)
        {
            var race = new Race(name, laps);
            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            //Creates a Race with the given name and laps and adds it to the RaceRepository.
            //If the Race with the given name already exists, throw an InvalidOperationException with message:
            //•	"Race {name} is already created."
            //If everything is successful you should return the following message:
            //•	"Race {name} is created."
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
            //Creates a Rider with the given name and adds it to the appropriate repository.
            //The method should return the following message:
            //"Rider {name} is created."
            //If a rider with the given name already exists in the rider repository, throw an ArgumentException with message"Rider {name} is already created."
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            var sb = new StringBuilder();
            var count = 1;
            foreach (var rider in race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).ToList())
            {
                if (count == 1)
                {
                    sb.AppendLine($"Rider {rider.Name} wins {race.Name} race.");
                }
                else if (count == 2)
                {
                    sb.AppendLine($"Rider {rider.Name} is second in {race.Name} race.");
                }
                else if (count == 3)
                {
                    sb.AppendLine($"Rider {rider.Name} is third in {race.Name} race.");
                }
                count++;
                if (count == 4)
                {
                    break;
                }
            }
            //This method is the biggest deal.If everything is valid, you should arrange all Riders and then return the three fastest Riders.To do this you should sort all Riders in descending order by the result of CalculateRacePoints method in the Motorcycle object.At the end, if everything is valid remove this Race from race repository.
            //If the Race does not exist in RaceRepository, throw an InvalidOperationException with message:"Race {name} could not be found."
            //If the participants in the race are less than 3, throw an InvalidOperationException with message:
            //•	"Race {race name} cannot start with less than 3 participants."
            //If everything is successful, you should return the following message:
            //"Rider {first rider name} wins {race name} race."
            //"Rider {second rider name} is second in {race name} race."
            //"Rider {third rider name} is third in {race name} race."
            raceRepository.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
