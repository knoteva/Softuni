<?php
include('01. List Posts from MySQL.php');

$mysqli->set_charset("utf8");
$id = $_GET['id'];

if (isset($id)) {
    $st = $mysqli->prepare("DELETE FROM posts WHERE post_id = ?");
    $st->bind_param("i", $id);
    $st->execute();
    header("Location: index.php");
}
