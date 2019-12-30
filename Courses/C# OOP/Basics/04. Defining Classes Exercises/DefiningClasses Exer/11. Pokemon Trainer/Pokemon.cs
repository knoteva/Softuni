namespace PokemonTrainer
{
    public class Pokemon
    {
        private string pokemonName;
        private string element;
        private int health;

        public Pokemon(string pokemonName, string element, int health)
        {
            PokemonName = pokemonName;
            Element = element;
            Health = health;
        }

        public string PokemonName { get => pokemonName; set => pokemonName = value; }
        public string Element { get => element; set => element = value; }
        public int Health { get => health; set => health = value; }

        public void ReduceHealth()
        {
            this.Health -= 10;
        }
    }
}
