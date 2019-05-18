<?php
$listAge = [];
$listSalary = [];
$listPosition = [];

while(true) {
    $input = readline();
    if ($input === 'filter base') {
        break;
    }
    $line = explode(' -> ',$input);
    $name = $line[0];
    $information = $line[1];

    if (ctype_digit($information)) {
        $listAge[$name] = $information;
    } else if (is_numeric($information)) {
        $listSalary[$name] = $information;
    } else {
        $listPosition[$name] = $information;
    }
}

$command = readline();
if ($command == "Age") {
    foreach ($listAge as $name => $age) {
        echo "Name: $name" . PHP_EOL;
        echo "Age: $age" . PHP_EOL;
        echo "====================" . PHP_EOL;
    }
}
 else if ($command == "Salary") {
    foreach ($listSalary as $name => $salary) {
        echo "Name: $name" . PHP_EOL;
        echo "Salary: " .number_format($salary, 2, '.', '') . PHP_EOL;
        echo "====================" . PHP_EOL;
    }
}
else if ($command == "Position") {
    foreach ($listPosition as $name => $position) {
        echo "Name: $name" . PHP_EOL;
        echo "Position: $position" . PHP_EOL;
        echo "====================" . PHP_EOL;
    }
}