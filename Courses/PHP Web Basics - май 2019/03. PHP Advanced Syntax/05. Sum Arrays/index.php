<?php
$arr1 = array_map('intval', explode(" ", readline()));
$arr2 = array_map('intval', explode(" ", readline()));
$len1 = count($arr1);
$len2 = count($arr2);
$result = [];
$largegLength = max($len1, $len2);

//echo $largegLength . PHP_EOL;
for ($i = 0; $i < $largegLength; $i++) {
    $result = $arr1[$i % $len1] + $arr2[$i % $len2];

    if ($i >= $largegLength) {
        break;
    }
    echo $result. " ";
}