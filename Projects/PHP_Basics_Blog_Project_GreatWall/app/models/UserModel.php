<?php

class UserModel extends MainModel {

	/**
	 * Performs user login.
	 *
	 * @return array Array, containing the user info as an object
	 */
	public function login() {
		if (!empty($_POST['username']) && !empty($_POST['password'])) {

			$username = $_POST['username'];
			$password = $_POST['password'];
			$hashedPass = $this->getHash($username);

			if (password_verify($password, $hashedPass)) {

				$query = $this->db->prepare('SELECT * FROM users WHERE username=:username AND password=:password LIMIT 1');
				$query->execute([':username' => $username, ':password' => $hashedPass]);
				$user = $query->fetchAll(PDO::FETCH_OBJ);

				return empty($user[0]) ? false : $user[0];
			}
		}

	}

	/**
	 * Performs user registration.
	 *
	 * @return boolean
	 */
	public function register() {
		////////////////////////////////////////
		// TODO: Each user can add comments //
		////////////////////////////////////////
		if (!empty($_POST['username'])
			&& !empty($_POST['firstname']) && !empty($_POST['lastname'])
			&& !empty($_POST['password']) && !empty($_POST['email'])) {

			$username = $_POST['username'];
			$firstname = $_POST['firstname'];
			$lastname = $_POST['lastname'];
			$password = password_hash($_POST['password'], PASSWORD_DEFAULT);
			$email = $_POST['email'];
			$role = 'user';

			$query = $this->db->prepare('INSERT INTO users(username, firstname, lastname, password, email, role) VALUES(:username, :firstname, :lastname, :password, :email, :role)');

			return $query->execute([
				':username' => $username,
				':firstname' => $firstname,
				':lastname' => $lastname,
				':password' => $password,
				':email' => $email,
				':role' => $role,
			]);
		}

		return false;
	}

	/**
	 * Checks if the currently logged in user is the admin.
	 *
	 * @return boolean
	 */
	public function isAdmin() {
		if (isset($_SESSION['username'])) {
			if ($_SESSION['role'] != 'admin') {
				return false;
			} else {
				return true;
			}
		}

		return false;
	}

	/**
	 * Returns the hashed password of a given username.
	 *
	 * @param  string $username
	 * @return string
	 */
	private function getHash($username) {
		$query = $this->db->query("SELECT password FROM users WHERE username='{$username}'");
		$result = $query->fetchAll(PDO::FETCH_OBJ);
		if (empty($result)) {
			return false;
		} else {
			return $result[0]->password;
		}
	}
    public  function  changeUsername($newUsername){
        if(isset($newUsername)){
            $query = "UPDATE users SET username =:username WHERE id=:id";
            $result = $this->db->prepare($query);
            return $result->execute([
                ":username"=>$newUsername,
                ":id"=>$_SESSION['id']
            ]);
        }else{
            return false;
        }
    }
    public  function  changePassword($newPassword){
        if(isset($newPassword)){
            $query = "UPDATE users SET password =:password WHERE id=:id";
            $result = $this->db->prepare($query);
            return $result->execute([
                ":password"=>password_hash($newPassword,PASSWORD_DEFAULT),
                ":id"=>$_SESSION['id']
            ]);
        }else{
            return false;
        }
    }

}
