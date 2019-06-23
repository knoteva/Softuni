<?php
//declare(strict_types = 1);
require_once "Book.php";
require_once "GoldenEditionBook.php";

$author = explode(" ", "");
//$author = explode(" ", readline());
$bookName = "Valid Book";
//$bookName = readline();
$price = 0;
//$price = floatval(readline());
$bookType = "GOLD";
//$bookType = readline();

$book = null;
if ($bookType == "STANDARD") {
    try {
        $book = new Book($bookName, $author, $price);
    } catch (Exception $ex) {
        echo $ex->getMessage();
    }
} else if ($bookType == "GOLD") {
    try {
        $book = new GoldenEditionBook($bookName, $author, $price);
    } catch (Exception $ex) {
        echo $ex->getMessage();
    }
} else {
    echo "Type is not valid!";
}
echo $book;