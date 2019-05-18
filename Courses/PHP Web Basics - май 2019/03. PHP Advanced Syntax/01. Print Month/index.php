<?php
$month = (int)readline();
$monthArray = ["January", "February", "March", "April", "May", "June",  "July", "August", "September", "October", "November", "December"];
if ($month < 1 || $month > 12) {
    echo "Invalid Month!";
} else {
    echo $monthArray[$month - 1];
}