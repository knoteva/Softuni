<?php
function isVolume($x, $y, $z)
{
    $x1 = 10;
    $x2 = 50;
    $y1 = 20;
    $y2 = 80;
    $z1 = 15;
    $z2 = 50;
    if ($x >= $x1 and $x <= $x2) {
        if ($y >= $y1 and $y <= $y2) {
            if ($z >= $z1 and $z <= $z2) {
                return true;
            }
        }
    }
    return false;
}
$input = array_map('floatval', explode(', ', readline()));
$counter = count($input);
for ($i = 0; $i < $counter; $i += 3){
    $x = $input[$i];
    $y = $input[$i + 1];
    $z = $input[$i + 2];
    if (isVolume($x, $y, $z)){
        echo 'inside'.PHP_EOL;
    }else{
        echo 'outside'.PHP_EOL;
    }
}