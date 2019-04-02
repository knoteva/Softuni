<html>
<head>
    <meta charset="UTF-8">
    <title>Word Mapping</title>
    <style>
        input {
            display: block;
            margin-top: 7px;
        }
    </style>
</head>
<body>
<form action="" method="post">
    <textarea name="input" cols="50" rows="3"></textarea>
    <input type="submit" value="count words" name="submit"/>
</form>
<?php
if (isset($_POST['submit'])):
    $input = strtolower($_POST['input']);
    $words = preg_split('/\W+/', $input, null, PREG_SPLIT_NO_EMPTY);
    foreach ($words as $word) {
        //$word = strtolower($word);
        $counts = array_count_values($words);
        //var_dump($counts);
    }

    ?>
    <table>
        <tbody>
        <?php
        foreach ($counts as $key => $count) {
            echo "<tr><td>$key</td><td>$count</td></tr>";
        }
        ?>
        </tbody>
    </table>
<?php
endif
?>
</body>
</html>