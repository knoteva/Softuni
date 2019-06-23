<?php
//$input = array_map('floatval', explode(', ', '-1, -2, 3.5, 0, 0, 2'));
$input = array_map('floatval', explode(', ', readline()));
$x1 = $input[0];
$y1 = $input[1];
$x2 = $input[2];
$y2 = $input[3];
$x3 = $input[4];
$y3 = $input[5];

function distanceBetweenPoints($x1, $y1, $x2, $y2) {

    return sqrt(($x2 - $x1) * ($x2 - $x1) + ($y2 - $y1) * ($y2 - $y1));

}

$distance123 = distanceBetweenPoints($x1, $y1, $x2, $y2) + distanceBetweenPoints($x2, $y2, $x3, $y3);
$distance132 = distanceBetweenPoints($x1, $y1, $x3, $y3) + distanceBetweenPoints($x3, $y3, $x2, $y2);
$distance213 = distanceBetweenPoints($x2, $y2, $x1, $y1) + distanceBetweenPoints($x1, $y1, $x3, $y3);

$shortestDistance = min($distance123, $distance132, $distance213);

if($shortestDistance == $distance123) {
    echo '1->2->3: '.$shortestDistance;
    return;
}

if($shortestDistance == $distance132) {
    echo '1->3->2: '.$shortestDistance;
    return;
}

if($shortestDistance == $distance213) {
    echo '2->1->3: '.$shortestDistance;
    return;
}
