<?php
//$input = [2, 10, 3];
$input = array_map('intval', explode(' ', readline()));
$counter = count($input);
while ($counter > 1){
    $condensed = [];
    for ($i = 0; $i < $counter - 1; $i++){
        $condensed[$i] = $input[$i] + $input[$i + 1];
    }
    $input = $condensed;
    $counter = count($input);
}
echo $input[0];