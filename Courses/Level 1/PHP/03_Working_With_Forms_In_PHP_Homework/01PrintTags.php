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
    <form action="01PrintTags.php" method="post">
        <label for="input">Enter Tags</label>
        <input type="text" name="input"/>
        <input type="submit" value="submit"/>
    </form>

    <?php
    if (isset($_POST['input'])) {
        $tags = explode(", ", htmlentities($_POST['input']));

        foreach ($tags as $key => $t) {
            echo "$key: $t<br>";
        }
    }
    ?>
    </body>
</html>