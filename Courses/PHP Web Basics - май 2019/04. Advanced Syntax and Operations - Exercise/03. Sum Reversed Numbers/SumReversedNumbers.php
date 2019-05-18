<?php

$arr = [123, 234, 12];

//$arr = array_map('intval', explode(" ", readline()));

$sum = 0;

$arrReversed = [];
for ($i = 0; $i < count($arr); $i++) {
    $sum += intval(strrev($arr[$i]));
    //array_push($arrReversed, strrev($arr[$i]));
}
//echo array_sum($arrReversed);
echo ($sum);

echo array_reduce(
    explode(" ", readline()),
    function ($sum, $el) {
        return $sum += intval(strrev($el));
    },
    0
);
