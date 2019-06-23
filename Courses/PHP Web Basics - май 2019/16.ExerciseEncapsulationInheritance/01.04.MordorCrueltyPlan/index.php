<?php
include "FoodFactory.php";
include "MoodFactory.php";
$allFood = explode(',', strtolower(readline()));
$totalPoints = 0;
foreach ($allFood as $food){
    $food = new FoodFactory($food);
    $totalPoints .= $food->getPoints();
}
$mood = new MoodFactory($totalPoints);
echo $totalPoints . "\n";
echo $mood->getMood();