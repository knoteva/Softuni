<?php


class Citizen implements PersonInterface, Identifiable, Birthable
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
     * @var
     */
    private $birthDate;

    /**
     * @var string
     */
    private $id;

    /**
     * Citizen constructor.
     * @param string $name
     * @param int $age
     */
    public function __construct(string $name, int $age, string $id, string $birthDate)
    {
        $this->setName($name);
        $this->setAge($age);
        $this->setId($id);
        $this->setBirthdate($birthDate);
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


    public function getBirthdate(): string
    {
        return $this->birthDate;
    }

    public function setBirthdate(string $birthDate)
    {
        $this->birthDate = $birthDate;
    }

    public function getId(): string
    {
        return $this->id;
    }

    public function setId(string $id)
    {
        $this->id = $id;
    }

    public function __toString()
    {
        $output = $this->getName().PHP_EOL.$this->getAge().PHP_EOL.$this->getId().PHP_EOL.$this->getBirthdate();
        return $output;
    }
}