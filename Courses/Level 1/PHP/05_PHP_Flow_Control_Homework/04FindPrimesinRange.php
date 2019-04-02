<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Find Primes in Range</title>
    <style>

    </style>
</head>
<body>
<form action="" method="get">
    <label for="start">Starting Index:</label>
    <input type="text" name="start" id="start"/>
    <label for="end">End:</label>
    <input type="text" name="end" id="end"/>
    <input type="submit" name='submit'/>
</form>
<?php

function isPrime($num) {
    if ($num < 2) {
        return false;
    } else if ($num == 2) {
        return true;
    } else {
        for ($i = 2; $i <= (int)sqrt($num); $i++) {
            if ($num % $i == 0) {
                return false;
            }
        }
    }
    return true;
}

if (isset($_GET['submit'])):
    $start = $_GET['start'];
    $end = $_GET['end'];
    $nums = array();
    for ($i = $start; $i <= $end; $i++):
        if (isPrime($i)): ?>
            <strong><?php echo $i ?></strong>
        <?php else:
            echo $i;
        endif;
        if ($i != $end):
            echo ", ";
        endif;
    endfor;
endif;

?>
</body>
</html>
