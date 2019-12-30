namespace Google
{
    public class Pokemon
    {
        private string pokemonName;
        private string pokemonType;

        public Pokemon(string pokemonName, string pokemonType)
        {
            PokemonName = pokemonName;
            PokemonType = pokemonType;
        }

        public string PokemonName { get => pokemonName; set => pokemonName = value; }
        public string PokemonType { get => pokemonType; set => pokemonType = value; }

        public override string ToString()
        {
            return $"{pokemonName} {pokemonType}";
        }
    }
}
