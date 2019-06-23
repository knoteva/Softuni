<form method = "post">
    <div>Title</div>
    <input type="text" name="title">
    <div>Content</div>
    <textarea name="content"></textarea>
    <button type="submit" name="edit">EDIT</button>
</form>
<?php
include '01. List Posts from MySQL.php';
if (isset($_POST['title']) && isset($_POST['content'])) {
    $title = $_POST['title'];
    $content = $_POST['content'];
    //$date = (new DateTime())->format('Y.m.d');

    $stmt = $mysqli->prepare("UPDATE posts SET name = ?, address= ? WHERE post_id=?");
    $stmt->bind_param("ss", $title, $content);
    $stmt->execute();
    if (isset($_POST['posts'])) {
        header('Location: ' . "index.php");
    }

}