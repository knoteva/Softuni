<?php

interface PersonInterface
{
    public function getName(): string;
    public function setName(string $name);
    public function getAge(): int;
    public function setAge(int $age);
}


class Citizen implements PersonInterface
{
    /**
     * @var string
     */
    private $name;
    /**
     * @var int
     */
    private $age;

    /**
     * Citizen constructor.
     * @param string $name
     * @param int $age
     */
    public function __construct(string $name, int $age)
    {
        $this->setName($name);
        $this->setAge($age);
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function setName(string $name)
    {
        $this->name = $name;
    }

    public function getAge(): int
    {
        return $this->age;
    }

    public function setAge(int $age)
    {
        $this->age = $age;
    }

    public function __toString()
    {
        $output = $this->getName().PHP_EOL.$this->getAge();
        return $output;
    }

}

$name = trim(readline());
$age = intval(readline());
$citizen = new Citizen($name, $age);
echo $citizen;