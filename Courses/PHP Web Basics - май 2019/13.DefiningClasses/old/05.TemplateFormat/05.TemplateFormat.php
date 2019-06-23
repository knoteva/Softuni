<?php

$line = explode(', ', readline());

PrintHeader();

for($i = 0; $i < count($line); $i += 2){
    $question = $line[$i];
    $answer = $line[$i + 1];

    PrintQuestionAnswer($question, $answer);
}

PrintFooter();


function PrintHeader(){
    echo '<?xml version="1.0" encoding="UTF-8"?>' . PHP_EOL . '<quiz>' . PHP_EOL;
}

function PrintQuestionAnswer($q, $a){
    echo '<question>' . PHP_EOL . $q . PHP_EOL . '</question>' . PHP_EOL;
    echo '<answer>' . PHP_EOL . $a . PHP_EOL . '</answer>' . PHP_EOL;
}

function PrintFooter(){
    echo '</quiz>';
}