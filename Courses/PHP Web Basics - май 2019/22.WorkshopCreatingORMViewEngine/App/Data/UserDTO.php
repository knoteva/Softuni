<?php

namespace App\Data;

class UserDTO
{
    /**
     * @var int
     */
    private $id;
    /**
     * @var string
     */
    private $username;
    /**
     * @var string
     */
    private $password;
    /**
     * @var string
     */
    private $firstName;
    /**
     * @var string
     */
    private $lastName;
    /**
     * @var \DateTime
     */
    private $bornOn;

    /**
     * UserDTO constructor.
     * @param string $username
     * @param string $password
     * @param string $firstName
     * @param string $lastName
     * @param string $bornOn
     * @param int $id
     * @return UserDTO
     */
    public static function create(string $username, string $password, string $firstName, string $lastName, string $bornOn, int $id = null)
    {
        return (new UserDTO())
            ->setUsername($username)
            ->setPassword($password)
            ->setUsername($firstName)
            ->setLastName($lastName)
            ->setBornOn($bornOn)
            -> setId($id);
    }



    /**
     * @return int
     */
    public function getId(): int
    {
        return $this->id;
    }

    /**
     * @param int $id
     * @return UserDTO
     */
    public function setId(int $id): UserDTO
    {
        $this->id = $id;
        return $this;
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
     * @return UserDTO
     */
    public function setUsername(string $username): UserDTO
    {
        $this->username = $username;
        return $this;
    }

    /**
     * @return string
     */
    public function getPassword(): string
    {
        return $this->password;
    }

    /**
     * @param string $password
     * @return UserDTO
     */
    public function setPassword(string $password): UserDTO
    {
        $this->password = $password;
        return $this;
    }

    /**
     * @return string
     */
    public function getFirstName(): string
    {
        return $this->firstName;
    }

    /**
     * @param string $firstName
     * @return UserDTO
     */
    public function setFirstName(string $firstName): UserDTO
    {
        $this->firstName = $firstName;
        return $this;
    }

    /**
     * @return string
     */
    public function getLastName(): string
    {
        return $this->lastName;
    }

    /**
     * @param string $lastName
     * @return UserDTO
     */
    public function setLastName(string $lastName): UserDTO
    {
        $this->lastName = $lastName;
        return $this;
    }

    /**
     * @return string
     */
    public function getBornOn(): string
    {
        return $this->bornOn;
    }

    /**
     * @param string $bornOn
     * @return UserDTO
     */
    public function setBornOn(string $bornOn): UserDTO
    {
        $this->bornOn = $bornOn;
        return $this;
    }

}