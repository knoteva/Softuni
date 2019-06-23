<?php

spl_autoload_register(/**
 * @param $class
 */ function ($class) {
    $class = str_replace("\\", DIRECTORY_SEPARATOR, $class);
    require_once "{$class}.php";
});
/**
 * @var \Vehicles\VehicleAbstract $vehicles[]
 */
$vehicles = [];
$factory = new \Factories\VehicleFactory();
const NUMBERVEHICLES = 3;

for ($i = 0; $i < NUMBERVEHICLES; $i++) {
    list($type, $quantity, $consumption, $tankCapacity) = explode(' ', readline());
    try {
        $vehicle = $factory->create($type, $quantity, $consumption, $tankCapacity);
    } catch (Exception $ex) {
        echo $ex->getMessage();
    }

    $vehicles[$type] = $vehicle;
}

$n = readline();
for ($i = 0; $i < $n; $i++) {
    list($action, $type, $param) = explode(' ', readline());
    try {
        $vehicle = $vehicles[$type];
        $action = strtolower($action);
        echo $vehicle->$action($param);
    } catch (Exception $ex) {
        echo $ex->getMessage();
    }

}

foreach ($vehicles as $vehicle) {
    echo $vehicle.PHP_EOL;
}