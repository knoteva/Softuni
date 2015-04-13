<?php
function repeat($nums)
{
    $numbers = [];
    $result = [];

    for ($i = 102; $i <= 987; $i++) {
        $numbers = (string)$i;
        if ($numbers[0] != $numbers[1] && $numbers[1] != $numbers[2] && $numbers[0] != $numbers[2] && $i <= $nums) {
            $result[] = $i;
        }
    }

   if (count($result) > 0) {
        print_r(join(", ", $result));
    } else {
        echo "no";
    }


}


repeat(5555);
//repeat(145);
//repeat(15);
//repeat(247);
?>