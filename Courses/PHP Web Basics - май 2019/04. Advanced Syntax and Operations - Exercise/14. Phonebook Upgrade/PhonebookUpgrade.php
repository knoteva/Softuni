<?php

$phone_book = [];

while (($input = readline()) !== "END") {
    //echo $input. PHP_EOL;

    if ($input === "ListAll"){
        ksort($phone_book);
        foreach ($phone_book as $name => $phone){
            echo "$name -> $phone_book[$name]".PHP_EOL;
        }
        continue;
    }

    $tokens = explode(' ', $input);
    $command = $tokens[0];
    $name = $tokens[1];
    if ($command === 'A') {
        $phone = $tokens[2];
//        if (!array_key_exists($name, $phone_book)){
//            $phone_book[$name] = "";
//        }
        $phone_book[$name] = $phone;
    }
    if ($command === 'S') {
        if (array_key_exists($name, $phone_book)) {
            echo "$name -> $phone_book[$name]" . PHP_EOL;
        } else {
            echo "Contact $name does not exist." . PHP_EOL;
        }
    }

//    echo $command. PHP_EOL;
//    echo $name. PHP_EOL;
//    echo $phone. PHP_EOL;
}