<?php
$input = explode(', ', readline());
$rows = intval($input[0]);
$matrix = [];
$first_sum = 0;
$second_sum = 0;
for ($i = 0; $i < $rows; $i++) {
    $matrix[$i] = array_map('intval', explode(' ', readline()));
}
for ($i = 0; $i < $rows; $i++){
    $first_sum += $matrix[$i][$i];
    $second_sum += $matrix[$i][count($matrix) - $i -1];
}
$result = $first_sum - $second_sum;
echo abs($result).PHP_EOL;
echo count($matrix);