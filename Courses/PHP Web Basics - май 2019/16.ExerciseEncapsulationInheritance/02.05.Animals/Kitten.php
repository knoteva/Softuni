<?php

require_once "SoundProducible.php";
require_once "Animal.php";
require_once "Cat.php";

class Kitten extends Cat
{
    const SOUND = "Miau";
    const GENDER = "Female";

    /**
     * Kitten constructor.
     */
    public function __construct(string $name, int $age)
    {
        parent:: __construct($name, $age, self::GENDER);
    }

    public function ProduceSound()
    {
        return self::SOUND;
    }
}