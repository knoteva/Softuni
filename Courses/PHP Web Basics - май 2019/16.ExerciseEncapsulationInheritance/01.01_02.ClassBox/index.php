<?php

declare(strict_types = 1);

require_once "Box.php";


list($length, $width, $height) = array_map("floatval", [readLine(), readLine(), readLine()]);

try {
    $box = new Box($length, $width, $height);
    echo $box;
} catch (Exception $ex) {
    echo $ex->getMessage();
}
