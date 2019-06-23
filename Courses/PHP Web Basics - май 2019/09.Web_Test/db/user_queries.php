<?php
function register (PDO $db, string $username, string $password): bool
{
    $query = "
        INSERT INTO
         users (
            username,
            password
         )
         VALUES (
            ?,
            ?
         )
    ";
    $statement = $db->prepare($query);
    $result = $statement->execute (
        [
            $username,
            password_hash($password, PASSWORD_ARGON2I)
        ]
    );
    return $result;
}