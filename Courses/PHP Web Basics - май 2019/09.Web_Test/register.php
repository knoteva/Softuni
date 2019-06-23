<?php
include('db/db_connection.php');
$response = '';
if (isset($_POST['username'], $_POST['password'])) {

    $username = $_POST['username'];
    $password = $_POST['password'];
    include_once ("db/user_queries.php");
    $result = register($db, $username, $password);

    if ($result) {
        header("Location: login.php");
    } else {
       $response = 'Error!';
    }
}
include_once("templates/register_form.php");