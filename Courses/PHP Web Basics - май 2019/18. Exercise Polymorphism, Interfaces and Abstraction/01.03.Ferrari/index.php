<?php

require_once "Ferrari.php";
require_once "CarInterface.php";


$person = trim(fgets(STDIN));
/**
 * @var Ferrari[] $ferrari
 */
$ferrari = [];
$ferrari = new Ferrari($person);

echo $ferrari;