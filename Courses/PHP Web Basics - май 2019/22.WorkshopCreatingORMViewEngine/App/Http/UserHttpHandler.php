<?php

namespace App\Http;

use App\Data\UserDTO;
use App\Service\Users\UserServiceInterface;

class UserHttpHandler extends UserHttpHandlerAbstract
{
    public function login(UserServiceInterface $userService, array $formData = [])
    {
        if (isset($formData['login'])) {
            $this->handleLoginProcess($userService, $formData);
        } else {
            $this->rendler("users/login");
        }
    }
    
    public function register(UserServiceInterface $userService, array $formData = [])
    {
        if (isset($formData['register'])) {
            $this->handleRegisterProcess($userService, $formData);
        } else {
            $this->rendler("users/register");
        }
    }

    private function handleRegisterProcess(UserServiceInterface $userService, array $formData)
    {
        $userDTO = UserDTO::create(
            $formData['username'],
            $formData['password'],
            $formData['first_name'],
            $formData['last_name'],
            $formData['born_on']
        );

        /**@var UserServiceInterface $userService*/
        if ($userService->register($userDTO, $formData['confirm_password'])) {
            $this->redirect("login.php");
        } else {

        }
    }

    private function handleLoginProcess(UserServiceInterface $userService, array $formData)
    {
        /**
         * @var UserServiceInterface $userService
         */
        $user = $userService->login($formData['username'], $formData['password']);
        //var_dump($user);
        if (null !== $user) {
            $_SESSION['id'] = $user->getId();
            $this->redirect("profile.php");
        } else {
            $this->rendler('users/login');
        }
    }
}