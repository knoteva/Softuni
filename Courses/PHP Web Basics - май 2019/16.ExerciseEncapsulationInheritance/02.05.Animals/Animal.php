<?php

require_once "SoundProducible.php";
abstract class Animal implements SoundProducible
{
    const INVALID_INPUT_MSG = "Invalid input!";
    /**
     * @var string
     */
    private $name;
    /**
     * @var int
     */
    private $age;
    /**
     * @var string
     */
    private $gender;

    /**
     * Animal constructor.
     * @param string $name
     * @param int $age
     * @param string $gender
     * @throws Exception
     */
    public function __construct(string $name, int $age, string $gender)
    {
        $this->setName($name);
        $this->setAge($age);
        $this->setGender($gender);
    }

    /**
     * @param string $name
     * @throws Exception
     */
    public function setName(string $name): void
    {
        if (empty(trim($name))) {
            throw new Exception(self::INVALID_INPUT_MSG);
        }
        $this->name = $name;
    }

    /**
     * @param int $age
     * @throws Exception
     */
    public function setAge(int $age): void
    {
        if (empty(trim($age)) || $age <= 0) {
            throw new Exception(self::INVALID_INPUT_MSG);
        }
        $this->age = $age;
    }

    /**
     * @param string $gender
     * @throws Exception
     */
    public function setGender(string $gender): void
    {
        if (empty(trim($gender))) {
            throw new Exception(self::INVALID_INPUT_MSG);
        }
        $this->gender = $gender;
    }
    public function __toString()
    {
        $output =  " {$this->name} {$this->age} {$this->gender}" . PHP_EOL . $this->produceSound();;
        return $output;
    }
}