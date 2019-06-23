<?php

class Trainer
{
    /**
     * @var string string
     */
    private $name;

    /**
     * @var int
     */
    private $badges;

    /**
     * @var Pokemon[][]
     */
    private $pokemons;

    /**
     * Trainer constructor.
     * @param string $name
     */
    public function __construct(string $name)
    {
        $this->name = $name;
        $this->badges = 0;
        $this->pokemons = [];
    }

    /**
     * @return int
     */
    public function getBadges(): int
    {
        return $this->badges;
    }


    public function catchPokemon(Pokemon $pokemon) : void
    {
        $this->pokemons[$pokemon->getElement()][] = $pokemon;
    }

    public function receiveBadge() : void
    {
        $this->badges++;
    }
    public function hasPokemonsByElement(string $element) :bool
    {
        return key_exists($element, $this->pokemons) && count($this->pokemons[$element]) > 0;
    }
    public  function hitPokemons($dmg) : void
    {
        foreach ($this->pokemons as $type => $pokemonsBType) {
            foreach ($pokemonsBType as $key => $pokemon) {
                $pokemon->hit($dmg);
                if (!$pokemon->isAlive()) {
                    unset($this->pokemons[$type][$key]);
                }
            }
        }
    }
    public function __toString()
    {
        $pokemonCount = 0;
        foreach ($this->pokemons as $pokemonsByType) {
            $pokemonCount += count($pokemonsByType);
        }
        return $this->name . ' '. $this->badges. ' '. $pokemonCount;
    }
}


class Pokemon
{
    private $name;
    private $element;
    private $health;

    public function __construct(string $name, string $element, int $health)
    {
        $this->name = $name;
        $this->element = $element;
        $this->health = $health;
    }


    public function getName(): string
    {
        return $this->name;
    }

    public function getElement(): string
    {
        return $this->element;
    }

    public function getHealth(): int
    {
        return $this->health;
    }
    public function isAlive() : bool
    {
        return $this->getHealth() > 0;
    }
    public function hit(int $dmg) : void
    {
        $this->health -= max(0, $dmg);
    }


}

/**
 * @var Trainer[] $trainers
 */
$trainers = [];

while (($line = readline()) != "Tournament") {
    list($trainerName, $pokemonName, $element, $health) = explode(' ', $line);
    if (!key_exists($trainerName, $trainers)) {
        $trainers[$trainerName] = new Trainer($trainerName);
    }
    $trainer = $trainers[$trainerName];
    $trainer->catchPokemon(new Pokemon($pokemonName,$element, $health));
}

while (($line = readline()) != "End") {
    foreach ($trainers as $trainer) {
        if ($trainer->hasPokemonsByElement($line)) {
            $trainer->receiveBadge();
        } else {
            $trainer->hitPokemons(10);
        }
    }
}
uksort( $trainers, function($key1, $key2) use ($trainers) {
    $trainer1 = $trainers[$key1];
    $trainer2 = $trainers[$key2];

    return $trainer2->getBadges() <=> $trainer1->getBadges();
});

echo implode(PHP_EOL, $trainers);








