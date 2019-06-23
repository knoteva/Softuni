<?php

include_once "IdentifiableInterface.php";
include_once "BirthdayInterface.php";
include_once "BuyerInterface.php";

class Citizen implements IdentifiableInterface, BirthdayInterface, BuyerInterface
{

    private $name;
    private $age;
    private $id;
    private $birthday;
    private $food = 0;


    public function __construct(string $name, int $age, string $id, string $birthday)
    {
        $this->name = $name;
        $this->age = $age;
        $this->id = $id;
        $this->birthday = $birthday;
    }


//    public function getName(): string
//    {
//        return $this->name;
//    }

    public function getId(): string
    {
        return $this->id;
    }

    public function getBirthday(): string
    {
        return $this->birthday;
    }

    public function BuyFood()
    {
        $this->setFood($this->getFood() + 10);
    }
    public function getFood(): int
    {
        return $this->food;
    }
    public function setFood(int $value)
    {
        $this->food = $value;
    }
}