<?php


namespace Vehicles;


class Truck extends VehicleAbstract
{
    const FUELMODIFIER = 1.6;
    const REFUELMODIFIER = 0.95;

    public function __construct(float $fuelQuantity, float $fuelConsumption, float $tankCapacity)
    {
        parent::__construct($fuelQuantity, $fuelConsumption, $tankCapacity, self::FUELMODIFIER);
    }

    public function refuel(float $liters): void
    {
        parent::refuel($liters * self::REFUELMODIFIER);
    }
}