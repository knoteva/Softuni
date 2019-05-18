<?php

$phone_book = [];

while (($input = readline()) !== "Over") {
    $tokens = explode(' : ', $input);
    $firstElement  = $tokens[0];
    $secondElement = $tokens[1];

    if (!is_numeric($firstElement)) {
        $name = $firstElement;
        $phone = $secondElement;
    }
    else {
        $name = $secondElement;
        $phone = $firstElement;
    }
    $phone_book[$name] = $phone;
}
ksort($phone_book);
foreach ($phone_book as $name => $phone){
    echo "$name -> $phone_book[$name]".PHP_EOL;
}
