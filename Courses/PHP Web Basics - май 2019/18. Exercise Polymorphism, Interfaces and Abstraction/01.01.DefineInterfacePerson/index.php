<?php



require_once 'PersonInterface.php';
require_once 'Citizen.php';

$name = trim(readline());
$age = intval(readline());
$citizen = new Citizen($name, $age);
echo $citizen;