<?php

namespace Vehicles;

interface VehiclesInterface
{
    public function drive(float $distance) : string;
    public function refuel(float $liters);
}