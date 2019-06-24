<?php


namespace App\Repository;


use App\Data\UserDTO;
use Database\DatabaseInterface;

class UserRepository implements UserRepositoryInterface
{
    /**
     * @var DatabaseInterface
     */
    private $db;

    /**
     * UserRepository constructor.
     * @param DatabaseInterface $db
     */
    public function __construct(DatabaseInterface $database)
    {
        $this->db = $database;
    }

    public function insert(UserDTO $userDTO): bool
    {
        $this->db->query(
            "INSERT INTO users (username, password, first_name, last_name, born_on)
                    VALUES(?, ?, ?, ?, ?)"
        )->execute([
            $userDTO->getUsername(),
            $userDTO->getPassword(),
            $userDTO->getFirstName(),
            $userDTO->getLastName(),
            $userDTO->getPassword(),
        ]);
        return true;
    }

    public function update(int $id, UserDTO $userDTO): bool
    {
        $this->db->query(
            "
                UPDATE users
                SET 
                    username = ?,
                    password = ?,
                    first_name = ?,
                    last_name = ?,
                    born_on = ?    
                WHERE id = ?
                "
        )->execute([
            $userDTO->getUsername(),
            $userDTO->getPassword(),
            $userDTO->getFirstName(),
            $userDTO->getLastName(),
            $userDTO->getPassword(),
            $id
        ]);
        return true;
    }

    public function delete(int $id): bool
    {
        $this->db->query(
            "DELETE FROM users WHERE Id = ?"
        ) ->execute([$id]);
        return true;
    }

    public function findOneByUsername(string $username): ?UserDTO
    {
        return $this->db->query(
            "SELECT id, username, password, first_name, last_name, born_on
                    FROM users
                    WHERE username = ?
                    "
        )->execute([$username])->fetch(UserDTO:: class)
        ->current();
    }

    public function findOneById(int $id): ?UserDTO
    {
        return $this->db->query(
            "SELECT id, username, password, first_name, last_name, born_on
                    FROM users
                    WHERE Id = ?
                    "
        )->execute([$id])->fetch(UserDTO:: class)
            ->current();
    }

    /**
     * @return \Generator|UserDTO[]
     */
    public function findAll(): \Generator
    {
       return  $this->db->query(
            "SELECT id, username, password, first_name, last_name, born_on
                    FROM users       
                   "
        )->execute()->fetch(UserDTO:: class);
    }
}