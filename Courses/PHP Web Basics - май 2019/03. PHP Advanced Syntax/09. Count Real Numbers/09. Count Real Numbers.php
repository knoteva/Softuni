<?php
$input = explode(' ', readline());
$dict = [];
for ($i = 0; $i < count($input); $i++){
    if (!key_exists($input[$i], $dict)) {
    $dict[$input[$i]] = 0;
    }
    $dict[$input[$i]]++;
}
ksort($dict);
foreach ($dict as $num => $freq) {
    echo "$num -> $freq".PHP_EOL;
}
