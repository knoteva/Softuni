<?php

require_once "SoundProducible.php";
require_once "Animal.php";
require_once "Cat.php";

class Tomcat extends Cat
{
    const SOUND = "Give me one million b***h";
    const GENDER = "Male";

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