namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            List<Trainer> trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                //“<TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>
                string trainerName = input.Split(" ")[0];
                string pokemonName = input.Split(" ")[1];
                string pokemonElement = input.Split(" ")[2];
                int pokemonHealth = int.Parse(input.Split(" ")[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!trainers.Any(t => t.TrainerName == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                Trainer trainer = trainers.First(t => t.TrainerName == trainerName);
                trainer.AddPokemon(pokemon);
            }

            var element = string.Empty;

            while ((element = Console.ReadLine()) != "End")
            {
                foreach(var trainer in trainers)
            {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.IncreaseBadges();
                    }
                    else
                    {
                        trainer.ReducePokemonsHealth();
                        trainer.RemoveDead();
                    }
                }
            }

            trainers
            .OrderByDescending(t => t.Badges)
            .ToList()
            .ForEach(Console.WriteLine);
        }
    }
}
