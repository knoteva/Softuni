<?php

require_once "Human.php";
require_once "Student.php";
require_once "Worker.php";

//$studentLine = explode(" ", 'Afo Mk321 0812111');
$studentLine = explode(" ", readline());

list($studentFirstName, $studentLastName, $studentFacultyNumber) = $studentLine;

try {
    $student = new Student($studentFirstName, $studentLastName, $studentFacultyNumber);
} catch(Exception $ex) {
    echo $ex->getMessage();
    return;
}
//$workerLine = explode(" ", 'Ivcho Ivancov 1590 10');
$workerLine = explode(" ", readline());
try {
    $worker = new Worker($workerLine[0], $workerLine[1], $workerLine[2], $workerLine[3]);

} catch(Exception $ex) {
    echo $ex->getMessage();
    return;
}
$worker = new Worker($workerLine[0], $workerLine[1], $workerLine[2], $workerLine[3]);

echo $student;
echo $worker;



