<?php

interface PasswordInterface
{
    public function hashPassword($password):void;
}

interface PointsInterface
{
    public function calculatePoints() : string;
}

class Demon implements PasswordInterface, PointsInterface {
    /**
     * @var string
     */
    private $username;
    /**
     * @var string
     */
    private $password;
    /**
     * @var int
     */
    private $level;
    /**
     * @var float
     */
    private $energy;

    /**
     * Demon constructor.
     * @param $username
     * @param string $password
     * @param int $level
     * @param float $energy
     */
    public function __construct($username, float $energy, int $level, string $password = "")
    {
        $this->setUsername($username);
        $this->hashPassword($password);
        $this->setLevel($level);
        $this->setEnergy($energy);
    }

    /**
     * @param string $username
     */
    private function setUsername($username): void
    {
        $this->username = $username;
    }

    /**
     * @param string $password
     */
    private function setPassword(string $password): void
    {
        $this->password = $password;
    }

    /**
     * @param int $level
     */
    private function setLevel(int $level): void
    {
        $this->level = $level;
    }

    /**
     * @param float $energy
     */
    private function setEnergy(float $energy): void
    {
        $this->energy = $energy;
    }

    /**
     * @return string
     */
    public function getUsername(): string
    {
        return $this->username;
    }

    /**
     * @return string
     */
    public function getPassword(): string
    {
        return $this->password;
    }

    /**
     * @return int
     */
    public function getLevel(): int
    {
        return $this->level;
    }

    /**
     * @return float
     */
    public function getEnergy(): float
    {
        return $this->energy;
    }

    public function hashPassword($password): void
    {
        $len = strlen($this->username);
        $hashedPassword = strval($len * 217);
        $this->setPassword($hashedPassword);
    }

    public function calculatePoints(): string
    {
        $points = $this->getLevel() * $this->getEnergy();
        $points = number_format(strval($points),1, ".", "");
        return $points;
    }

    public function __toString() :string
    {
        $name = '"' . $this->getUsername() . '"';
        $pass = '"' . $this->getPassword() . '"';
        $result = $name . " | " . $pass . " -> Demon" . "\n" . $this->calculatePoints();
        return $result;
    }
}

class Archangel implements PasswordInterface, PointsInterface {
    /**
     * @var string
     */
    private $username;
    /**
     * @var string
     */
    private $password;
    /**
     * @var int
     */
    private $level;
    /**
     * @var int
     */
    private $mana;

    /**
     * Demon constructor.
     * @param $username
     * @param string $password
     * @param int $level
     * @param int $mana
     */
    public function __construct($username, int $level, int $mana, string $password = "")
    {
        $this->setUsername($username);
        $this->hashPassword($password);
        $this->setLevel($level);
        $this->setMana($mana);
    }

    /**
     * @param string $username
     */
    private function setUsername($username): void
    {
        $this->username = $username;
    }

    /**
     * @param string $password
     */
    private function setPassword(string $password): void
    {
        $this->password = $password;
    }

    /**
     * @param int $level
     */
    private function setLevel(int $level): void
    {
        $this->level = $level;
    }

    /**
     * @param int $mana
     */
    private function setMana(int $mana): void
    {
        $this->mana = $mana;
    }

    /**
     * @return string
     */
    public function getUsername(): string
    {
        return $this->username;
    }

    /**
     * @return string
     */
    public function getPassword(): string
    {
        return $this->password;
    }

    /**
     * @return int
     */
    public function getLevel(): int
    {
        return $this->level;
    }

    /**
     * @return int
     */
    public function getMana(): int
    {
        return $this->mana;
    }

    public function hashPassword($password): void
    {
        $len = strlen($this->username);
        $username = $this->username;
        $hashedPassword = strrev($username) . strval($len * 21);
        $this->setPassword($hashedPassword);
    }

    public function calculatePoints(): string
    {
        $points = $this->getLevel() * $this->getMana();
        return strval($points);
    }

    public function __toString() :string
    {
        $name = '"' . $this->getUsername() . '"';
        $pass = '"' . $this->getPassword() . '"';
        $result = $name . " | " . $pass . " -> Archangel" . "\n" . $this->calculatePoints();
        return $result;
    }
}

$data = explode(" | ", readline());
if ($data[1] == "Demon") {
    $demon = new Demon($data[0], $data[2], floatval($data[3]));
    echo $demon;
} else {
    $archangel = new Archangel($data[0], intval($data[2]), intval($data[3]));
    echo $archangel;
}