<?php
$input = explode(', ', readline());
$dict = [];
for ($i = 0; $i < count($input); $i += 2){
    if (!key_exists($input[$i], $dict)) {
        $dict[$input[$i]] = (int)$input[$i + 1];
    } else {
        $dict[$input[$i]] += (int)$input[$i + 1];
    }
}
foreach ($dict as $num => $freq) {
echo "$num => $freq".PHP_EOL;
}