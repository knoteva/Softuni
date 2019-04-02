<?php

function dump($var) {
    if (is_numeric($var)) {
        echo var_dump($var);
    } else {
    echo gettype($var) . "\n";
    }
}

$input = [
    "hello",
    15,
    1.234,
    array(1,2,3),
    (object)[2,34]
];

foreach ($input as $var) {
    dump($var);
}

?>