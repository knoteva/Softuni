<?php


namespace Factories;


use Vehicles\VehicleAbstract;
use Vehicles\VehiclesInterface;

class VehicleFactory implements VehicleFactoryInterface
{

    /**
     * @param string $type
     * @param float $quantity
     * @param float $consumption
     * @param float $thankCapacity
     * @return VehicleAbstract
     * @throws \Exception
     */
    public function create(string $type, float $quantity, float $consumption, float $thankCapacity): VehicleAbstract
    {
        $className = 'Vehicles\\'.$type;

        if(!class_exists($className)) {
            throw new \Exception("Invalid vehicle type");
        }
        $vehicle = new $className($quantity, $consumption, $thankCapacity);
        return $vehicle;
    }
}