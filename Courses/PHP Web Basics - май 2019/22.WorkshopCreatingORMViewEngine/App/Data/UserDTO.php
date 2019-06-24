<?php

namespace App\Data;

class UserDTO
{

    private $id;
    private $username;
    private $password;
    private $firstName;
    private $lastName;
    private $bornOn;


    public static function create($username, $password, $firstName, $lastName, $bornOn, $id = null) : UserDTO
    {
         return(new UserDTO())
             ->setUsername($username)
             ->setPassword($password)
             ->setUsername($firstName)
             ->setLastName($lastName)
             ->setBornOn($bornOn)
             ->setId($id);
    }

    public function getId()
    {
        return $this->id;
    }

    public function setId(int $id): UserDTO
    {
        $this->id = $id;
        return $this;
    }

    public function getUsername()
    {
        return $this->username;
    }

    public function setUsername(string $username): UserDTO
    {
        $this->username = $username;
        return $this;
    }

    public function getPassword(): string
    {
        return $this->password;
    }

    public function setPassword(string $password): UserDTO
    {
        $this->password = $password;
        return $this;
    }

    public function getFirstName()
    {
        return $this->firstName;
    }

    public function setFirstName(string $firstName): UserDTO
    {
        $this->firstName = $firstName;
        return $this;
    }

    public function getLastName()
    {
        return $this->lastName;
    }

    public function setLastName(string $lastName): UserDTO
    {
        $this->lastName = $lastName;
        return $this;
    }

    public function getBornOn()
    {
        return $this->bornOn;
    }

    public function setBornOn(string $bornOn): UserDTO
    {
        $this->bornOn = $bornOn;
        return $this;
    }
}