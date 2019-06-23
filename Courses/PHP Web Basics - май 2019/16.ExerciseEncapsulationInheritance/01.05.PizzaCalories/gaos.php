<?php

$arr = array_map('intval', explode(" ", "1 2 3 4 5"));
$sizeFirst = count($arr);

if ($sizeFirst % 2 == 0) {
    for ($i = 0; $i < count($arr); $i++) {
        $first = array_shift($arr);
        $last = array_pop($arr);
        $res = $first + $last;
        array_splice($arr, 1, 0, $res);
    }
} else if ($sizeFirst % 2 != 0) {
    $middle = $arr[intval($sizeFirst / 2)];
    $arr = array_diff( $arr, [$middle]);
    for ($i = 0; $i < count($arr); $i++) {
        $first = array_shift($arr);
        $last = array_pop($arr);
        $res = $first + $last;
        array_splice($arr, 1, 0, $res);
    }
}
echo implode(" ", $arr);
if ($sizeFirst % 2 != 0) {
    echo " " . $middle;
}