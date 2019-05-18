<?php
//$input = explode(' ', '3 5 5 hi pi HO Hi 5 ho 3 hi pi');
$input = explode(' ', readline());
$dict = [];
$arr = [];
for ($i = 0; $i < count($input); $i++){
    $wordLower = strtolower($input[$i]);
    if (!key_exists($wordLower, $dict)) {
        $dict[$wordLower] = 0;
    }
    $dict[$wordLower]++;
}

foreach ($dict as $word => $freq) {
    //$word = strtolower($words);
    if ($freq % 2 !== 0 && !in_array($word, $arr)){
        array_push($arr, $word);
    }
}
echo implode(", ", $arr);
