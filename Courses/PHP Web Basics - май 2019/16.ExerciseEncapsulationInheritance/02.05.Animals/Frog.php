<?php

require_once "SoundProducible.php";
require_once "Animal.php";

class Frog extends Animal
{
    const SOUND = "Frogggg";
    public function ProduceSound()
    {
        return self::SOUND;
    }
}