<?php
$numbers = [2, 3, 4, 2, 1];
//$numbers = explode(" ", readline());
$maxCount = 0;
$maxNumber = 0;
for ($row = 0; $row < count($numbers); $row++) {
    $currCount = 0;
    for ($col = $row; $col < count($numbers) - 1; $col++) {
        if ($numbers[$col] < $numbers[$col + 1]) {
            $currCount++;

            if ($currCount > $maxCount) {
                $maxCount = $currCount;
                $maxNumber = $row;
            }
        }
        else {
            break;
        }
    }
}


for ($i = 0; $i <= $maxCount; $i++) {
    echo $numbers[$i + $maxNumber] . " ";
}