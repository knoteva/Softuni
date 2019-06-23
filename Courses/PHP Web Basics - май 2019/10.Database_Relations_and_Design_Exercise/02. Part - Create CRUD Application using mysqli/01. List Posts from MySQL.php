<?php
$mysqli = new mysqli('localhost', 'root', '123+', 'blog');
$mysqli-> set_charset(("utf8"));

if ($mysqli->connect_errno) {
    die('Cannot connect to MySQL');
}

////include ("01. List Posts from MySQL.php"); // If we use a separated file for the code below.
//$result = $mysqli->query('SELECT * FROM posts ORDER BY date_created');
//if (!$result) {
//    die('Cannot connect to MySQL');
//}
//
//
//echo "<table border='2'>\n";
//
//echo "<tr><th>Title</th><th>Content</th><th>Date</th></tr>";
//
//while($row=$result->fetch_assoc()){
//    $title = htmlspecialchars(($row['title']));
//    $body = htmlspecialchars($row['content']);
//    $date = (new DateTime($row['date_created']))->format('d.m.Y');
//
//    echo "<tr><th>$title</th><th>$body</th><th>$date</th></tr>";
//}
//
//echo "</table>\n";