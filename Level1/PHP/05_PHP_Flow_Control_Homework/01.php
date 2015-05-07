<style>
    table{
        border: 1px solid black;
    }
    td{
        border: 1px solid black;
    }

</style>


<?php
$sum =0;
echo "<table>";
echo "<thead><td>Number:</td><td>Square:</td></thead>";
for($i = 0; $i <= 100; $i++){
    if($i % 2 == 0){

        if (fmod(sqrt($i), 1) == 0){
            $result = sqrt($i);
            echo "<tr><td>$i</td><td>$result</td><tr/>";

        }else{
            $current = sqrt($i);
            $result = number_format($current, 2);
            echo "<tr><td>$i</td><td>$result</td><tr/>";
        }
        $sum += sqrt($i);

    }
}
$sum = number_format($sum, 2);
echo "<tr><td>Total:</td><td>$sum</td><tr/>";
echo "<table/>";
?>
