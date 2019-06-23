<?php

include_once "Robot.php";
include_once "Citizen.php";
//include_once "IdentifiableInterface.php";
/**
 * @var $entries IdentifiableInterface[]
 */
$entries = [];
while (true) {
    $tokens = explode(" ", readLine());
    if ($tokens[0] == "End") {
        break;
    }
    if (count($tokens) == 3) {
        $entries[] = new Citizen($tokens[0], intval($tokens[1]), $tokens[2]);
    } else {
        $entries[] = new Robot(...$tokens);
    }
}
$bannedId = readline();
foreach ($entries as $entry) {
    if (preg_match("/" . $bannedId . "$/", $entry->getId())) {
        writeLine($entry->getId());
    }
}
function writeLine($content)
{
    echo $content . PHP_EOL;
}