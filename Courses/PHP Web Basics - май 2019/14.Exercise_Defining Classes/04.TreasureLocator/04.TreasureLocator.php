<?php

$input = array_map('floatval', explode(', ', readline()));
$map = [];
for ($i = 0; $i < count($input); $i += 2) {
    $result = findATreasure($input[$i], $input[$i + 1]);
    $map[] = $result;
}
foreach ($map as $item) {
    echo $item.PHP_EOL;
}

function findATreasure($x, $y){
    if (($x >= 1 and $x <= 3) and ($y >= 1 and $y <= 3)){
        $treasure = 'Tuvalu';
    }elseif (($x >= 8 and $x <= 9) and ($y >= 0 and $y <= 1)){
        $treasure = 'Tokelau';
    }elseif (($x >=5 and $x <=7)and ($y >= 3 and $y <= 6)){
        $treasure = 'Samoa';
    }elseif (($x >= 0 and $x <= 2) and ($y >= 6 and $y <= 8)){
        $treasure = 'Tonga';
    }elseif (($x >= 4 and $x <= 9) and ($y >= 7 and $y <= 8)){
        $treasure = 'Cook';
    }else{
        $treasure = 'On the bottom of the ocean';
    }
    return $treasure;
}
