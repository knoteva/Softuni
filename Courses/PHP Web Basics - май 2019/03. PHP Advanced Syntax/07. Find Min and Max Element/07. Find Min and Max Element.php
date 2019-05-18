<?php
$matrixSize = explode(', ',readline());
$rows = $matrixSize[0];
$cols = $matrixSize[1];
$minElement = PHP_INT_MAX;
$maxElement = PHP_INT_MIN;
for ($i = 0; $i < $rows; $i++) {
    $matrix[$i] = array_map('intval', explode(', ', readline()));
}
foreach ($matrix as $arr){
    foreach ($arr as $number){
        if ($number < $minElement){
            $minElement = $number;
        }
        if ($number > $maxElement){
            $maxElement = $number;
        }
    }
}
echo "Min: ".$minElement.PHP_EOL;
echo "Max: ".$maxElement;