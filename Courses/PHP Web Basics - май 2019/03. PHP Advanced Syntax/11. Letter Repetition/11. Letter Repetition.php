<?php
//$input = 'aaabbaaabbbccc';
$input =readline();
$dict = [];
for ($i = 0; $i < strlen($input); $i++){
    if (!key_exists($input[$i], $dict)) {
        $dict[$input[$i]] = 0;
    }
    $dict[$input[$i]]++;
}

foreach ($dict as $num => $freq) {
    echo "$num -> $freq".PHP_EOL;
}
