<?php
$input = explode(', ', readline());
$rows = intval($input[0]);
$columns = intval($input[1]);
$matrix = [];
for ($i = 0; $i < $rows; $i++) {
    $matrix[$i] = array_map('intval', explode(', ', readline()));
}
$best_sum = 0;
$sum = 0;
$x_counter = 0;
$start_x = 0;
$stop_x = 0;
$start_y = 0;
$stop_y = 0;
for ($j = 0; $j < $rows - 1; $j++) {
    for ($i = 0; $i < $columns - 1; $i++) {
        for ($x = $x_counter; $x < min($x_counter + 2, $rows); $x++) {
            for ($y = $i; $y < min($i + 2, $columns); $y++) {
                $sum += $matrix[$x][$y];
            }
        }
        if ($sum > $best_sum) {
            $best_sum = $sum;
            $start_x = $matrix[$x - 2][$y - 2];
            $stop_x = $matrix[$x - 2][$y - 1];
            $start_y = $matrix[$x - 1][$y - 2];
            $stop_y = $matrix[$x - 1][$y - 1];
        }
        $sum = 0;
    }
    $x_counter++;
}
echo $start_x." ".$stop_x.PHP_EOL;
echo $start_y." ".$stop_y.PHP_EOL;
echo $best_sum;