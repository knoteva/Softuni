<?php

require_once "CharacterBase.php";

class Archangel extends CharacterBase
{
    /**
     * @var int
     */
    private $specialPoints;

    /**
     * Archangel constructor.
     * @param string $name
     * @param int $level
     * @param int $specialPoints
     */
    public function __construct(string $name, int $specialPoints, int $level)
    {
        parent::__construct($name, $level);
        $this->setSpecialPoints($specialPoints);
        $this->setHashedPassword();
    }


    public function getSpecialPoints()
    {
        return $this->specialPoints;
    }

    public function setSpecialPoints($points)
    {
        $this->specialPoints  =$points;
    }

    public function setHashedPassword()
    {
        $this->hashedPassword = strrev($this->getUsername())  . strlen($this->getUsername())* 21;
    }
    public function __toString()
    {
        return parent::__toString() . PHP_EOL
            . $this->getSpecialPoints() * $this->getLevel();
    }
}