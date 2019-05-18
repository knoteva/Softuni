<?php

$input = explode(' ', readline());
$rows = intval($input[0]);
$columns = intval($input[1]);
$matrix = [];
for ($i = 0; $i < $rows; $i++) {
    $matrix[$i] = array_map('intval', explode(' ', readline()));
}
$best_sum = 0;
$sum = 0;
$x_counter = 0;
$start_x = 0;
$middle_x = 0;
$stop_x = 0;
$start_y = 0;
$middle_y = 0;
$stop_y = 0;
$start_z = 0;
$middle_z = 0;
$stop_z = 0;
for ($j = 0; $j < $rows - 2; $j++) {
    for ($i = 0; $i < $columns - 2; $i++) {
        for ($x = $x_counter; $x < min($x_counter + 3, $rows); $x++) {
            for ($y = $i; $y < min($i + 3, $columns); $y++) {
                $sum += $matrix[$x][$y];
            }
        }
        if ($sum > $best_sum) {
            $best_sum = $sum;
            $start_x = $matrix[$x - 3][$y - 3];
            $middle_x = $matrix[$x - 3][$y - 2];
            $stop_x = $matrix[$x - 3][$y - 1];
            $start_y = $matrix[$x - 2][$y - 3];
            $middle_y = $matrix[$x - 2][$y - 2];
            $stop_y = $matrix[$x - 2][$y - 1];
            $start_z = $matrix[$x - 1][$y - 3];
            $middle_z = $matrix[$x - 1][$y - 2];
            $stop_z = $matrix[$x - 1][$y - 1];
        }
        $sum = 0;
    }
    $x_counter++;
}
echo "Sum = " . $best_sum . PHP_EOL;
echo $start_x . " " . $middle_x . " " . $stop_x . PHP_EOL;
echo $start_y . " " . $middle_y . " " . $stop_y . PHP_EOL;
echo $start_z . " " . $middle_z . " " . $stop_z;