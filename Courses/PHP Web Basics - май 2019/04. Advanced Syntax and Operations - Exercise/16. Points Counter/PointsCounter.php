<?php
$teamPoints = array();
$playerPoints = [];
//$str = 'Bry*%ant|LA|71';
$str = readline();
while ($str !== "Result") {

    $input = explode('|', $str);
    $first = $input[0];
    $second = $input[1];
    $points = intval($input[2]);

    $removedSymbols = array("@", "%", "&", "$", "*");
    $firstClean = str_replace($removedSymbols, "", $first);
    $secondClean = str_replace($removedSymbols, "", $second);
    if ($firstClean === strtoupper($firstClean)) {
        $team = $firstClean;
        $name = $secondClean;
    } else {
        $team = $secondClean;
        $name = $firstClean;
    }

    $teamPoints[$team][$name] = $points;

    $str = readline();
    arsort($teamPoints[$team]);
}

var_dump($teamPoints);
//arsort($playerPoints);

foreach ($teamPoints as $key => $player) {

    echo $key . " => " . array_sum ( $key) . "\n";
   // echo "Most points scored by " . key($teamPoints[$key]) . "\n";
}