<?php

include_once "BirthdayInterface.php";

class Pet implements BirthdayInterface
{

    private $name;
    private $birthday;
    public function __construct(string $name, string $birthday)
    {
        $this->name = $name;
        $this->birthday = $birthday;
    }

    public function getBirthday(): string
    {
        return $this->birthday;
    }
}