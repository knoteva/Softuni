<?php

require_once "SoundProducible.php";
require_once "Animal.php";

class Cat extends Animal
{
    const SOUND = "MiauMiau";
    public function ProduceSound()
    {
        return self::SOUND;
    }
}