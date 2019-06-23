<?php
$num = array_map('intval', str_split(101));
//$num = array_map('intval', str_split(readline()));
$result = makeAverage($num);
echo implode('', $result);

function makeAverage($number)
{
    while (true){
        $avg = calculateAverage($number);
        if ($avg > 5){
            break;
        }
        array_push($number,9);
    }
    return $number;
}

function calculateAverage($n)
{
    $average = array_sum($n) / count($n);
    return $average;
}
