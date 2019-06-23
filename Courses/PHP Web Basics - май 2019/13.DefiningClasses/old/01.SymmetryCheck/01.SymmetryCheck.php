<?php

function isPalindrome($str){
//    for ($i = 0; $i < strlen($str) / 2; $i++)
//        if ($str[$i] != $str[strlen($str) - $i - 1]){
//            return false;
//        }
//    return true;
    if($str !== strrev($str)){
        return false;
    }
    return true;
}

$input = readline();

if(isPalindrome($input)){
    echo "true";
} else {
    echo "false";
}
