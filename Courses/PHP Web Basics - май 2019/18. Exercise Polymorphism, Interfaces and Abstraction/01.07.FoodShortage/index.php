<?php

include_once "Robot.php";
include_once "Citizen.php";
require_once "Pet.php";
include_once "Rebel.php";

/**
 * @var $people BuyerInterface[]
 */
$people = [];
$numOfPeople = intval(readLine());

while ($numOfPeople) {
    $numOfPeople--;
    $tokens = explode(" ", readLine());
    if (count($tokens) === 4) {
        $people[$tokens[0]] = new Citizen($tokens[0], intval($tokens[1]), $tokens[2], $tokens[3]);
        continue;
    }
    if (count($tokens) === 3) {
        $people[$tokens[0]] = new Rebel($tokens[0], intval($tokens[1]), $tokens[2]);
    }
}
while (true) {
    $name = readLine();
    if ($name == "End") {
        break;
    }
    if (!array_key_exists($name, $people)) {
        continue;
    }
    $person = $people[$name];
    $person->buyFood();
}

$totalFood = 0;
foreach ($people as $person) {
    $totalFood += $person->getFood();
}
writeLine("{$totalFood}");

function writeLine($content)
{
    echo $content . PHP_EOL;
}