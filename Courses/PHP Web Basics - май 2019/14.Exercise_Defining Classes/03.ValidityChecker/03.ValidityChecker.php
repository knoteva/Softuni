<?php
$input = array_map('intval', explode(', ', '3, 0, 0, 4'));
//$input = array_map('intval', explode(', ', readline()));
$x1 = $input[0];
$y1 = $input[1];
$x2 = $input[2];
$y2 = $input[3];
calculateDistance($x1, $y1, 0, 0);
calculateDistance($x2, $y2, 0, 0);
calculateDistance($x1, $y1, $x2, $y2);

function calculateDistance($x1, $y1, $x2, $y2){
    $distance = sqrt(pow($x2 - $x1, 2) + pow($y2 - $y1, 2));
    $a = (int)$distance;
    $b = $distance;
    if ((int)$distance == $distance){
        echo sprintf("{%x1, %y1} to {%x2, %d} is valid".PHP_EOL, $x1, $y1, $x2, $y2);
    }else{
        echo sprintf("{%d, %d} to {%d, %d} is invalid".PHP_EOL, $x1, $y1, $x2, $y2);
    }
}
