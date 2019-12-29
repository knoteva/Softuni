using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string trainerName;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string trainerName)
        {
            TrainerName = trainerName;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string TrainerName { get => trainerName; set => trainerName = value; }
        public int Badges { get => badges; set => badges = value; }
        public List<Pokemon> Pokemons { get => pokemons; set => pokemons = value; }

        public void AddPokemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }

        public void IncreaseBadges()
        {
            Badges++;
        }

        public void ReducePokemonsHealth()
        {
            this.Pokemons.ForEach(p => p.ReduceHealth());
        }

        public void RemoveDead()
        {
            this.Pokemons = this.Pokemons
            .Where(p => p.Health > 0)
            .ToList();
        }

        public override string ToString()
        {
            return $"{trainerName} {Badges} {Pokemons.Count}";
        }
    }
}
