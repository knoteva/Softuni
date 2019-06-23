<?php
include ("header.php");
?>
<form method = "post">
    <div>Title</div>
    <input type="text" name="title">
    <div>Content</div>
    <textarea name="content"></textarea>
    <div><input type="submit" value="Post"></div>
</form>

<?php
include('01. List Posts from MySQL.php');
if (isset($_POST['title']) && isset($_POST['content'])) {
    $title = $_POST['title'];
    $content = $_POST['content'];
    $date = (new DateTime())->format('Y.m.d');
    //$date = date("Y d m");

    $stmt = $mysqli
        ->prepare("INSERT INTO posts(title, content, `date_created`) VALUES(?,?,?)");
    $stmt->bind_param("sss", $title, $content, $date);
    $stmt->execute();

    if ($stmt->affected_rows == 1){
        echo "Post created.";
    }
    else {
        die("Insert post failed.");
    }
    header("Location: index.php");
}
?>

