<?php

function getLimit($zone){
    switch ($zone){
        case 'motorway':
            $speedLimit = 130;
            break;
        case 'interstate':
            $speedLimit = 90;
            break;
        case 'city':
            $speedLimit = 50;
            break;
        case 'residential':
            $speedLimit = 20;
            break;
        default:
            echo "Not a Valid Input";
            $speedLimit = 1000;
    }
    return $speedLimit;
}

function printRadar($speed, $speedLimit){
    $difference = $speed - $speedLimit;
    if ($difference < 0){
        exit;
    }
    if ($difference <= 20){
        echo 'speeding';
        exit;
    }
    if ($difference <=40){
        echo 'excessive speeding';
        exit;
    }
    if ($difference > 40){
        echo 'reckless driving';
    }
}
$input_speed = (int)readline();
$input_zone = readline();

$limit = getLimit($input_zone);
printRadar($input_speed, $limit);