<?php

$arr = explode(" ", readline());
$arr = array_reverse($arr);

foreach ($arr as $num) {
    echo $num. " ";
}