<?php
$input = explode(', ', readline());
$dict = [];
for ($i = 0; $i < count($input); $i++){
    if (!key_exists($input[$i], $dict)) {
        $dict[$input[$i]] = 0;
    }
    $dict[$input[$i]]++;
}

foreach ($dict as $num => $freq) {
    if ($freq === 1){
        echo "$num ";
    }
}
