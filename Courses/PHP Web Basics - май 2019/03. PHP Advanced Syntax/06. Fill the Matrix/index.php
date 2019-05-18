<?php
$input = explode(', ',readline());
$matrix_size = intval($input[0]);
$method = $input[1];
$result = null;
if ($method === 'A'){
    $result = method_a($matrix_size);
}else{
    $result = method_b($matrix_size);
}
foreach ($result as $arr) {
    foreach ($arr as $number) {
        echo $number . " ";
    }
    echo PHP_EOL;
}
function method_a($size)
{
    $matrix = [];
    for ($i = 0; $i < $size; $i++) {
        $matrix[$i] = [];
        $counter = 1 + $i;
        for ($j = 0; $j < $size; $j++) {
            $matrix[$i][$j] = $counter;
            $counter += $size;
        }
    }
    return $matrix;
}
function method_b($size)
{
    $matrix = [];
    for ($i = 0; $i < $size; $i++) {
        $matrix[$i] = [];
        $counter = 1 + $i;
        for ($j = 0; $j < $size; $j++) {
            if ($j % 2 == 0){
                $matrix[$i][$j] = $counter;
                $counter += $size;
            }else{
                $matrix[$i][$j] = $size * ($j + 1) - $i;
                $counter += $size;
            }
        }
    }
    return $matrix;
}