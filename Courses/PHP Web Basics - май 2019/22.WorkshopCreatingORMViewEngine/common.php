<?php

session_start();
spl_autoload_register();

use App\Http\UserHttpHandler;
use App\Repository\UserRepository;
use App\Service\Encryption\ArgonEncryptionService;
use App\Service\Users\UserService;
use Core\Template;
use Database\PDODatabase;


$template = new Template();
$dbInfo = parse_ini_file("Config/db.ini");
$pdo = new PDO($dbInfo['dsn'], $dbInfo['user'], $dbInfo['pass']);
$db = new PDODatabase($pdo);
$userRepository = new UserRepository($db);
$encryptionService = new ArgonEncryptionService();
$userService = new UserService($userRepository, $encryptionService);
$userHttpHandler = new UserHttpHandler($template);