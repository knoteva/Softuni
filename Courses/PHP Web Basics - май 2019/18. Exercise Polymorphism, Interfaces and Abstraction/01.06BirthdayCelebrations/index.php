<?php

include_once "Robot.php";
include_once "Citizen.php";
require_once "Pet.php";
//include_once "IdentifiableInterface.php";
/**
 * @var $entries BirthdayInterface[]
 */
$entries = [];
while (true) {
    //$tokens = explode(" ","Pet Topcho 24/12/2000");
    $tokens = explode(" ", readLine());
    if ($tokens[0] == "End") {
        break;
    }
    $type = array_shift($tokens);
    if ($type == "Citizen") {
        $entries[] = new Citizen($tokens[0], intval($tokens[1]), $tokens[2], $tokens[3]);
    } else if ($type == "Pet") {
        $entries[] = new Pet($tokens[0], $tokens[1]);
    }
}

$year = readline();

if (count($entries) == 0) {
    echo "<no output>";
    return;
}

$count = 0;

foreach ($entries as $entry) {
    if (preg_match("/" . $year . "$/", $entry->getBirthday())) {
        writeLine($entry->getBirthday());
        $count++;
    }
}

if ($count === 0) {
    echo "<no output>";
}

function writeLine($content)
{
    echo $content . PHP_EOL;
}