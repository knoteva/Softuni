<?php

use App\Data\UserDTO;
use App\Http\UserHttpHandler;
use App\Repository\UserRepository;
use App\Service\Encryption\ArgonEncryptionService;
use App\Service\Users\UserService;
use Core\Template;
use Database\PDODatabase;

require_once "common.php";

$userHttpHandler->register($userService, $_POST);
/**
 * @var UserDTO $userDTO
 */
