<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Print Tag</title>
    <style>

        label {
            display: block;
            padding: 10px;
        }
    </style>
</head>
<body>
<form action="02MostFrequentTag.php" method="post">
    <label for="input">Enter Tags</label>
    <input type="text" name="input"/>
    <input type="submit" value="submit"/>
</form>

<?php
if (isset($_POST['input'])) {
    $tags = explode(", ", htmlentities($_POST['input']));
    $count = array_count_values($tags);
   //var_dump($count)."\n";
   //echo json_encode($count);
   arsort($count);
   // var_dump($count)."\n";
   // echo json_encode($count);
    foreach ($count as $key => $c) {
        //echo "$key: $c times<br>";
    }
    reset($count);
    echo "Most Frequent Tag is: " . key($count);
}
?>
</body>
</html>