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