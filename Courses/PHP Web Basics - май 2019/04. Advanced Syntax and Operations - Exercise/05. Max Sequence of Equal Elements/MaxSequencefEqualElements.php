<?php
$numbers = [3, 2, 2, 2, 1];
//$numbers = explode(" ", readline());
$maxCount = 0;
$maxNumber = 0;
for ($row = 0; $row < count($numbers); $row++) {
    $currCount = 0;
    for ($col = $row; $col < count($numbers); $col++) {
        if ($numbers[$row] == $numbers[$col]) {
            $currCount++;

            if ($currCount > $maxCount) {
                $maxCount = $currCount;
                $maxNumber = $numbers[$row];
            }
        }
        else {
            break;
        }
    }
}


for ($i = 0; $i < $maxCount; $i++) {
    echo $maxNumber . " ";
}