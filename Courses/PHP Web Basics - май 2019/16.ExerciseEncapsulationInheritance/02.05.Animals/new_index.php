Cat
Macka 12 Female
Dog
Sharo 132 Male
Beast!<?php

require_once "SoundProducible.php";
require_once "Animal.php";
require_once "Dog.php";
require_once "Cat.php";
require_once "Frog.php";
require_once "Kitten.php";
require_once "Tomcat.php";


/**
 * @var $animals Animal[]
 */
$animals = [];
$input = "";
    while (($input = readline()) != "Beast") {
        try {
            $animalData = explode(" ", readline());
            switch ($input) {
                case "Dog":
                $animals[0] = new Dog($animalData[0], $animalData[1], $animalData[2]);
                    break;
            }


        } catch (Exception $ex) {
            echo $ex->getMessage();
        }


    }
//foreach ($animals as $animal) {
    //echo $animal;
   // echo $animal->ProduceSound();
//}
