<?php
//$input = abv;
$input = str_split(strtolower(readline()));
$alphabets = [];
$index = 0;
foreach (range('a','z') as $alphabet){
    $alphabets[$alphabet] = $index;
    $index++;
}
foreach ($input as $item) {
    if (array_key_exists($item, $alphabets)){
        echo $item.' -> '.$alphabets[$item].PHP_EOL;
    }
}