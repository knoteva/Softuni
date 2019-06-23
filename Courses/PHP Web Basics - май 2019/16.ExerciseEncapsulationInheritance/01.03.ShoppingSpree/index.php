<?php
require_once "Person.php";
require_once "Product.php";


//readline()
$personData = preg_split("/[=;]/", readline(), - 1, PREG_SPLIT_NO_EMPTY);
//$personData = preg_split("/[=;]/", "Pesho=11;", - 1);
if (count($personData) === 0) {
    echo "Name cannot be empty";
    return;
}
//if ($personData[count($personData) - 1] == '') {
//    array_pop($personData);
//}
$people = [];

for ($i = 0; $i < count($personData) - 1; $i += 2) {
    $personName = $personData[$i];
    $personMoney = floatval($personData[$i + 1]);
    try {
        $people[$personName] = new Person($personName, $personMoney);
    } catch (Exception $ex) {
        echo $ex->getMessage();
        return;
    }

}
//print_r($people);

//readline()
$productData = preg_split("/[=;]/", readline(), - 1, PREG_SPLIT_NO_EMPTY);
//$productData = preg_split("/[=;]/", "Bread=10;", - 1);
//if ($productData[count($productData) - 1] == '') {
//    array_pop($productData);
//}
$products = [];

for ($i = 0; $i < count($productData) - 1; $i += 2) {
    $productName = $productData[$i];
    $productMoney = floatval($productData[$i + 1]);
    try {
        $products[$productName] = new Product($productName, $productMoney);
    } catch (Exception $ex) {
        echo $ex->getMessage();
        return;
    }
}
//print_r($products);
//while(true) {
while(($input = readline()) != "END") {
    //$input = "Pesho Bread";
    $data = explode(" ", $input);
    $personName = $data[0];
    $productName = $data[1];
    if (array_key_exists($personName, $people) && array_key_exists($productName, $products)) {
        /** @var Person $person */
        $person =  $people[$personName];
        try {
            $person->buyProduct($products[$productName]);
        } catch (Exception $ex) {
            echo $ex->getMessage();
        }
    }
}
//print_r($people);
foreach ($people as $person) {
    echo $person;
}

