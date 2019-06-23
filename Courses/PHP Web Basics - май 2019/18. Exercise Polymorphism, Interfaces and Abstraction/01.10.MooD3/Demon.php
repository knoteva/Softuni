<?php

require_once "CharacterBase.php";

class Demon extends CharacterBase
{
    /**
     * @var float
     */
    private $specialPoints;

    /**
     * Demon constructor.
     * @param string $username
     * @param int $level
     * @param float $specialPoints
     */
    public function __construct(string $username, float $specialPoints, int $level)
    {
        parent::__construct($username, $level);
        $this->setSpecialPoints($specialPoints);
        $this->setHashedPassword();
    }


    public function getSpecialPoints()
    {
        return $this->specialPoints;
    }

    public function setSpecialPoints($points)
    {
        $this->specialPoints = $points;
    }

    public function setHashedPassword()
    {
        $this->hashedPassword = strlen($this->getUsername()) * 217;
    }

    public function __toString()
    {
        return parent::__toString(). PHP_EOL
            . sprintf("%0.1f",round($this->specialPoints*$this->getLevel(),1));
    }
}