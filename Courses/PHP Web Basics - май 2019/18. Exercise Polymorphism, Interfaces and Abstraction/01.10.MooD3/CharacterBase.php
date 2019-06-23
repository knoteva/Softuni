<?php

include_once "CharacterInterface.php";

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