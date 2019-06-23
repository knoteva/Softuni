<?php


interface CharacterInterface
{

    public function getUsername() : string;
    public function setUsername(string $username);

    public function getHashedPassword() : string;
    //Може би не трябва да го има.
    //public function setHashedPassword(string $hashedPassword);

    public function getLevel() : int;
    public function setLevel(int $level);

    public function getSpecialPoints();
    public function setSpecialPoints($points);
}

abstract class CharacterBase implements CharacterInterface
{
    /**
     * @var string
     */
    public $hashedPassword;
    /**
     * @var string
     */
    private $username;
    /**
     * @var int
     */
    private $level;

    /**
     * CharacterBase constructor.
     * @param string $username
     * @param int $level
     */
    public function __construct(string $username, int $level)
    {
        $this->setUsername($username);
        $this->setLevel($level);
    }

    /**
     * @return string
     */
    public function getUsername(): string
    {
        return $this->username;
    }

    /**
     * @param string $username
     */
    public function setUsername(string $username): void
    {
        $this->username = $username;
    }

    /**
     * @return int
     */
    public function getLevel(): int
    {
        return $this->level;
    }

    /**
     * @param int $level
     */
    public function setLevel(int $level): void
    {
        $this->level = $level;
    }

    /**
     * @return string
     */
    public function getHashedPassword() : string
    {
        return $this->hashedPassword;
    }

    /**
     * @return string
     */
    public function __toString()
    {
        $output = "\"{$this->getUsername()}\" | \"{$this->getHashedPassword()}\" -> " . basename(get_class($this));

        return $output;
    }
}

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
    public function __construct(string $name, int $level, int $specialPoints)
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

/**
 * @var CharacterBase $character[]
 */
$character = [];

$input = explode(" | ", "A | Demon | 100.6 | 2");
//$input = explode(" | ", "\"Akasha\" | Archangel | 5 | 100");
//$input = explode(" | ", readline());

if ($input[1] === "Demon") {
    $character = new Demon($input[0], $input[2], $input[3]);
} else {
    $character = new Archangel($input[0], $input[2], $input[3]);
}
echo $character;