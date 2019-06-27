<?php

namespace App\Http;

use App\Data\ErrorDTO;
use App\Data\UserDTO;
use App\Service\Users\UserServiceInterface;

class UserHttpHandler extends UserHttpHandlerAbstract
{
    public function index(UserServiceInterface $userService)
    {
        $this->render("users/home/index");
    }

    public function login(UserServiceInterface $userService, array $formData = [])
    {
        if (isset($formData['login'])) {
            $this->handleLoginProcess($userService, $formData);
        } else {
            $this->render("users/login");
        }
    }
    
    public function register(UserServiceInterface $userService, array $formData = [])
    {
        if (isset($formData['register'])) {
            $this->handleRegisterProcess($userService, $formData);
        } else {
            $this->render("users/register");
        }
    }

    public function profile(UserServiceInterface $userService, array $formData = [])
    {
        if (!$userService->isLogged()) {
            $this->redirect("login.php");
        }

        $currentUser = $userService->currentUser();

        if (isset($formData['edit'])) {
            $this->handleEditProcess($userService, $formData);
        } else {
            $this->render("users/profile", $currentUser);
        }
    }

    public function showAll(UserServiceInterface $userService)
    {
        $this->render("users/all", $userService->getAll());
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
            $this->render("app/error", new ErrorDTO("The username already exist or passwords mismatch"));
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
            $this->render("app/error", new ErrorDTO("Username doesn't exist or password mismatch"));
        }
    }

    private function handleEditProcess(UserServiceInterface $userService, array $formData)
    {
        /**
         * @var UserServiceInterface $userService
         */
        $user = $userService->currentUser();
        $user->setUsername($formData['username']);
        $user->setPassword($formData['password']);
        $user->setFirstName($formData['first_name']);
        $user->setLastName($formData['last_name']);
        $user->setBornOn($formData['born_on']);

        if($userService->edit($user)) {
            $this->redirect("profile.php");
        }
    }
}