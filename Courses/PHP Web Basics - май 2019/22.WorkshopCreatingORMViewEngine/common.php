<?php


session_start();
spl_autoload_register();

$template = new \Core\Template();
$dbInfo = parse_ini_file("Config/db.ini");
$pdo = new PDO($dbInfo['dsn'], $dbInfo['user'], $dbInfo['password']);
$db = new \Database\PDODatabase($pdo);
$userRepository = new \App\Repository\UserRepository($db);
$encryptionService = new \App\Service\Encryption\ArgonEncryptionService();
$userService = new \App\Service\Users\UserService($userRepository, $encryptionService);
$userHttpHandler = new \App\Http\UserHttpHandler($template);