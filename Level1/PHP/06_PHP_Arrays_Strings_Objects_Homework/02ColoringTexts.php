<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Text Colorer</title>

</head>

<body>
<form action="" method="post">
    <input type="text" name="input-text" id="input-text" >
    <input type="submit" name="submit" id="submit" value="Color text">
</form>

<p>
    <?php if (isset($_POST['submit']) && isset($_POST['input-text'])):
        $sentence = $_POST['input-text'];
        foreach (str_split($sentence) as $letter):
            if (ord($letter) % 2 == 0): ?>
                <span style='color: red'><?php echo "$letter "; ?></span>
            <?php
            else: ?>
                <span style='color: blue'><?php echo "$letter "; ?></span>
            <?php
            endif;
        endforeach;
    endif;
    ?>
</p>
</body>
</html>
