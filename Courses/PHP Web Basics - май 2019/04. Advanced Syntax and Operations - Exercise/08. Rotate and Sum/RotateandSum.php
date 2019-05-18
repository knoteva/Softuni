<?php
$input = array_map('intval', explode(' ', readline()));
$n = intval(readline());
$sum = [];

for ($i = 0; $i < count($input); $i++){
    $sum[$i] = 0;
}
for ($i = 0; $i < $n; $i++) {
    $temp = array_pop($input);
    array_unshift($input, $temp);
    for ($j = 0; $j < count($input); $j++){
        $sum[$j] += $input[$j];
    }
}
echo implode(' ', $sum);