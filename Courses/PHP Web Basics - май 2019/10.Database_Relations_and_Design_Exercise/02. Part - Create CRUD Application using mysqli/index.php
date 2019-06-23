<?php
include ("01. List Posts from MySQL.php"); // If we use a separated file for the code below.
include ("header.php");

$result = $mysqli->query('SELECT * FROM posts ORDER BY date_created');

echo "<table border='2'>\n";

echo "<tr><th>Title</th>
        <th>Content</th>
        <th>Date</th>
        <th>Edit</th>
        <th>Delete</th>
</tr>";

while($stmt=$result->fetch_assoc()){
    $title = htmlspecialchars(($stmt['title']));
    $body = htmlspecialchars($stmt['content']);
    $date = (new DateTime($stmt['date_created']))->format('d.m.Y');
    $id = $stmt['post_id'];
    echo "<tr>
            <td>$title</td>
            <td>$body</td>
            <td>$date</td>
            <td><a href='edit.php?id=$id'>EDIT</a></td>
            <td><a href='delete.php?id=$id'>DELETE</a></td>
            
</tr>";
}

echo "</table>\n";