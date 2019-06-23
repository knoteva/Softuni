<?php

require_once "SoundProducible.php";
require_once "Animal.php";

class Dog extends Animal
{
    const SOUND = "BauBau";
    public function ProduceSound()
    {
         return self::SOUND;
    }
}