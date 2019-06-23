<?php

include_once "Smartphone.php";

$phone = new SmartPhone();
$phoneNumbers = explode(" ", readLine());
$websites = explode(" ", readLine());


foreach ($phoneNumbers as $phoneNumber) {
    try {
        echo $phone->call($phoneNumber).PHP_EOL;
    } catch (Exception $ex) {
        echo $ex->getMessage().PHP_EOL;
    }
}
foreach ($websites as $website) {
    try {
        echo $phone->browse($website).PHP_EOL;
    } catch (Exception $ex) {
        echo $ex->getMessage().PHP_EOL;
    }
}