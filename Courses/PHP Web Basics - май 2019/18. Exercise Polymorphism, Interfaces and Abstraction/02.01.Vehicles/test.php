<?php

interface VehiclesInterface
{
    public function drive(float $distance) : string;
    public function refuel(float $liters) : void;
}

abstract class VehicleAbstract implements VehiclesInterface
{

    private $fuelQuantity;
    private $fuelConsumption;
    private $modifier;

    public function __construct(float $fuelQuantity, float $fuelConsumption, float $modifier)
    {
        $this->fuelQuantity = $fuelQuantity;
        $this->modifier = $modifier;
        $this->fuelConsumption = $fuelConsumption + $this->modifier;
    }

    public function drive(float $distance): string
    {
        if ($this->fuelQuantity >= $this->fuelConsumption * $distance) {
            $this->fuelQuantity -= $this->fuelConsumption * $distance;
            return  basename(get_class($this)) . " travelled {$distance} km".PHP_EOL;
        }

        return  basename(get_class($this)) . " needs refueling".PHP_EOL;
    }

    public function refuel(float $liters): void
    {
        $this->fuelQuantity += $liters;
    }
    public function __toString()
    {
        return basename(get_class($this)) . ": " . number_format($this->fuelQuantity, 2, ".", "");
    }
}

interface VehicleFactoryInterface
{
    /**
     * @param string $type
     * @param float $quantity
     * @param float $consumption
     * @throws \Exception
     * @return VehicleAbstract
     */
    public function create(string $type, float $quantity, float $consumption) : VehicleAbstract;
}
class VehicleFactory implements VehicleFactoryInterface
{

    /**
     * @param string $type
     * @param float $quantity
     * @param float $consumption
     * @throws \Exception
     * @return VehicleAbstract
     */
    public function create(string $type, float $quantity, float $consumption): VehicleAbstract
    {
        $className = $type;

        if(!class_exists($className)) {
            throw new \Exception("Invalid vehicle type");
        }
        $vehicle = new $className($quantity, $consumption);
        return $vehicle;
    }
}

class Car extends VehicleAbstract
{
    const FUELMODIFIER = 0.9;

    public function __construct(float $fuelQuantity, float $fuelConsumption)
    {
        parent::__construct($fuelQuantity, $fuelConsumption, self::FUELMODIFIER);
    }
}

class Truck extends VehicleAbstract
{
    const FUELMODIFIER = 1.6;
    const REFUELMODIFIER = 0.95;

    public function __construct(float $fuelQuantity, float $fuelConsumption)
    {
        parent::__construct($fuelQuantity, $fuelConsumption, self::FUELMODIFIER);
    }

    public function refuel(float $liters): void
    {
        parent::refuel($liters * self::REFUELMODIFIER);
    }
}

$vehicles = [];
$factory = new VehicleFactory();

for ($i = 0; $i < 2; $i++) {
    list($type, $quantity, $consumption) = explode(' ', readline());
    $vehicle = $factory->create($type, $quantity, $consumption);
    $vehicles[$type] = $vehicle;
}

$n = readline();
for ($i = 0; $i < $n; $i++) {
    list($action, $type, $param) = explode(' ', readline());
    $vehicle = $vehicles[$type];
    $action = strtolower($action);
   echo $vehicle->$action($param);
}

foreach ($vehicles as $vehicle) {
    echo $vehicle.PHP_EOL;
}