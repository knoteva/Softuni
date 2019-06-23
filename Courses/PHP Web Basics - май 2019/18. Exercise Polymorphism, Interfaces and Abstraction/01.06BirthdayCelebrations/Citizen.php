<?php

include_once "IdentifiableInterface.php";
include_once "BirthdayInterface.php";

class Citizen implements IdentifiableInterface, BirthdayInterface
{

    private $name;
    private $age;
    private $id;
    private $birthday;
    public function __construct(string $name, int $age, string $id, string $birthday)
    {
        $this->name = $name;
        $this->age = $age;
        $this->id = $id;
        $this->birthday = $birthday;
    }

    public function getId(): string
    {
        return $this->id;
    }

    public function getBirthday(): string
    {
        return $this->birthday;
    }
}