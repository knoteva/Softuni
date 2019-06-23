<?php

namespace Vehicles;

class Bus extends VehicleAbstract
{
const FUELMODIFIER = 0;
    public function __construct(float $fuelQuantity, float $fuelConsumption, float $tankCapacity)
    {
        parent::__construct($fuelQuantity, $fuelConsumption, $tankCapacity, self::FUELMODIFIER);
    }
    protected function setFuelConsumption(float $consumption)
    {
        $fuelConsumption = $consumption;
    }
    public function refuel(float $liters)
    {
        if ($liters > $this->tankCapacity - $this->fuelQuantity) {
            throw new \Exception("Cannot fit fuel in tank");
        }
        $this->fuelQuantity += $liters;
    }

    /**
     * @param float $distance
     * @param bool $empty
     * @return string
     */
    public function drive(float $distance, bool $empty = false): string
    {
        if (!$empty) {
            $this->fuelConsumption += 1.4;
            $res = parent::drive($distance);
            $this->fuelConsumption -= 1.4;
            return $res;
        }
        return parent::drive($distance);
    }
}