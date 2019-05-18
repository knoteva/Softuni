<?php
$n = 6;
$k = 3;
//$n = intval(readline());
//$k = intval(readline());
$elements[0] = 1;

for ($i = 1; $i < $n; $i++){
    $sum = 0;
    for ($j = max(count($elements) - $k, 0); $j < min($k + $i, count($elements) + $i); $j++){
        $sum += $elements[$j];
    }
    $elements[$i] = $sum;
}
echo implode(' ', $elements);