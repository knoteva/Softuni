<?php

include_once "Topping.php";
include_once "Dough.php";
include_once "Pizza.php";

    //$pizzaTokens = explode(" ", "Pizza Meatfull 5");
    $pizzaTokens = explode(" ", readLine());
    try {
        $pizza = new Pizza(strtolower($pizzaTokens[1]), intval($pizzaTokens[2]));
    } catch (Exception $ex) {
        echo $ex->getMessage();
        return;
    }
    //$doughTokens = explode(" ", "Dough White cheWy 200");
    $doughTokens = explode(" ", readLine());
    try {
        $dough = new Dough(strtolower($doughTokens[1]), strtolower($doughTokens[2]), $doughTokens[3]);
    } catch (Exception $ex) {
        echo $ex->getMessage();
        return;
    }
    $pizza->setDough($dough);

    while (true) {
        //$toppingData = explode(" ", "Topping Meat 50");
        $toppingData = explode(" ", readline());
        if ($toppingData[0] === "END") {
            break;
        }
        try {
            $topping = new Topping(strtolower($toppingData[1]), intval($toppingData[2]));

        } catch (Exception $ex) {
            echo $ex->getMessage();
            return;
        }
        $pizza->addTopping($topping);
    }


echo $pizza;