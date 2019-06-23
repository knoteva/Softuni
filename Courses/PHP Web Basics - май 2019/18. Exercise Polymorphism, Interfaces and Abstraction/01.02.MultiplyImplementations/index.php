<?php

require_once 'PersonInterface.php';
require_once 'Citizen.php';
require_once "Birthable.php";
require_once "Identifiable.php";

$name = trim(readline());
$age = intval(readline());
$id = readline();
$birthdate = readline();

$citizen = new Citizen($name, $age, $id, $birthdate);
echo $citizen;