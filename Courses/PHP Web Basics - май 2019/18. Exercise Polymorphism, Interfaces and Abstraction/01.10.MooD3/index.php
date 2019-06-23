<?php
include_once "Demon.php";
include_once "Archangel.php";

/**
 * @var CharacterBase $character[]
 */
$character = [];

//$input = explode(" | ", "A | Demon | 100.6 | 2");
//$input = explode(" | ", "\"Akasha\" | Archangel | 5 | 100");
$input = explode(" | ", readline());

if ($input[1] === "Demon") {
    $character = new Demon($input[0], floatval($input[2]), floatval($input[3]));
} else {
    $character = new Archangel($input[0], intval($input[2]), intval($input[3]));
}
echo $character;

