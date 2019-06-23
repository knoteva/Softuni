<?php


namespace Vehicles;


class Car extends VehicleAbstract
{
    const FUELMODIFIER = 0.9;

    public function __construct(float $fuelQuantity, float $fuelConsumption, float $tankCapacity)
    {
        parent::__construct($fuelQuantity, $fuelConsumption, $tankCapacity, self::FUELMODIFIER);
    }
}