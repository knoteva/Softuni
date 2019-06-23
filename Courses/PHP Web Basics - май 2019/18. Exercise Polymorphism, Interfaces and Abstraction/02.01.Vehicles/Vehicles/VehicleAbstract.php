<?php

namespace Vehicles;

abstract class VehicleAbstract implements VehiclesInterface
{

    protected $fuelQuantity;
    protected $fuelConsumption;
    protected $modifier;
    protected $tankCapacity;


    public function __construct(float $fuelQuantity, float $fuelConsumption,  float $tankCapacity, float $modifier)
    {
        $this->fuelQuantity = $fuelQuantity;
        $this->modifier = $modifier;
        $this->fuelConsumption = $fuelConsumption + $this->modifier;
        $this->tankCapacity = $tankCapacity;
    }

    public function drive(float $distance): string
    {
        if ($this->fuelQuantity >= $this->fuelConsumption * $distance) {
            $this->fuelQuantity -= $this->fuelConsumption * $distance;
            return  basename(get_class($this)) . " travelled {$distance} km".PHP_EOL;
        }

        return  basename(get_class($this)) . " needs refueling".PHP_EOL;
    }

    public function refuel(float $liters)
    {
        $this->fuelQuantity += $liters;
    }
    public function __toString()
    {
        return basename(get_class($this)) . ": " . number_format($this->fuelQuantity, 2, ".", "");
    }
}