<?php

$num = (int)readline();
$operations = explode(", ", readline());

foreach ($operations as $operation) {
    $num =  calculate($num, $operation);
    echo $num.PHP_EOL;
}
function calculate($num, $oper) {

    switch ($oper) {
        case 'chop':
            $num /= 2;
            break;
        case 'dice':
            $num = sqrt($num);;
            break;
        case 'spice':
            $num += 1;
            break;
        case 'bake':
            $num *= 3;
            break;
        case 'fillet':
            $num *= 0.8;
            break;
    }
    return $num;
}
