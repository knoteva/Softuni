<?php


namespace Factories;


use Vehicles\VehicleAbstract;

interface VehicleFactoryInterface
{
    /**
     * @param string $type
     * @param float $quantity
     * @param float $consumption
     * @param float $thankCapacity
     * @return VehicleAbstract
     */
    public function create(string $type, float $quantity, float $consumption, float $thankCapacity) : VehicleAbstract;
}