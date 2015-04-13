<?php
    function sumTwoNumbers($firstNum, $secondNum){
        $sum = $firstNum + $secondNum;
        $sum = number_format($sum, 2);
        echo '$firstNum + $secondNum = ' . "$firstNum + $secondNum = $sum" . "\n";


        //echo '$firstNum + $secondNum  = ' . "$firstNum + $secondNum = " . number_format($sum, 2, '.', '') . "</br>";
    }
    sumTwoNumbers(2, 5);
    sumTwoNumbers(1.567808, 0.356);
    sumTwoNumbers(1234.5678, 333);

?>

//<?php
//function sum($array) {
//    $firstNumber = $array[0];
//    $secondNumber = $array[1];
//    $sum = $firstNumber + $secondNumber;
//    printf('$firstNumber + $secondNumber = %.2f + %.2f = %.2f' . "\n", $firstNumber, $secondNumber, $sum);
//};
//$input = [
//    [2, 5],
//    [1.567808, 0.356],
//    [1234.5678 , 333]
//];
//for ($i = 0; $i < count($input); $i++) {
//    sum($input[$i]);
//}