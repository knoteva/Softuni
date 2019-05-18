<?php
$n = (int)readline();
$arr = [];
for ($i = 0; $i < $n; $i++) {

    $arr[$i] = intval(readline());
}
//for ($i = $n - 1; $i >= 0; $i--)
//    echo $arr[$i] . " ";
//echo PHP_EOL;
$arr = array_reverse($arr);
foreach ($arr as $num) {
    echo $num. " ";
}