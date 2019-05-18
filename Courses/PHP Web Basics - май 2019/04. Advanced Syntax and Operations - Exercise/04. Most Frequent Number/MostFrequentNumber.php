<?php
$numbers = [3, 3, 2, 2, 2, 1];
//$numbers = explode(" ", readline());
$maxCount = 0;
$maxNumber = 0;
for ($row = 0; $row < count($numbers); $row++) {
    $currCount = 0;
    for ($col = $row; $col < count($numbers); $col++) {
        if ($numbers[$row] == $numbers[$col])
        {
            $currCount++;
        }
        if ($currCount > $maxCount) {
            $maxCount = $currCount;
            $maxNumber = $numbers[$row];
        }
    }
}
echo $maxNumber;


//$array = explode(" ", readline());
//$most = [];
//for ($i = 0; $i < count($array); $i++) {
//    if (!key_exists($array[$i], $most)) {
//        $most[$array[$i]] = 1;
//    } else {
//        $most[$array[$i]] += 1;
//    }
//}
//uksort($most, function ($key1, $key2) use ($most) {
//    return $most[$key2] <=> $most[$key1];
//});
//
//foreach ($most as $keys => $v) {
//    echo $keys;
//    return;
//}