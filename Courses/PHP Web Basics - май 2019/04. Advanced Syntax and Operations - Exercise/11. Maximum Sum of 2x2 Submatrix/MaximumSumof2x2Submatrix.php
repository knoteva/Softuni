<?php
$input = explode(", ", readline());
$rows = $input[0];
$cols = $input[1];
$biggestSum = 0;
$biggestIndex = [0, 0];
$matrix = [];
for($row = 0; $row < $rows; $row++)
{
    $matrix[$row] = explode(", ", readline());
}
for($row = 0; $row < $rows - 1; $row++)
{
    for($col = 0; $col < $cols - 1; $col++)
    {
        if(($matrix[$row][$col] + $matrix[$row][$col + 1] + $matrix[$row + 1][$col] + $matrix[$row + 1][$col + 1]) > $biggestSum)
        {
            $biggestSum = $matrix[$row][$col] + $matrix[$row][$col + 1] + $matrix[$row + 1][$col] + $matrix[$row + 1][$col + 1];
            $biggestIndex[0] = $row;
            $biggestIndex[1] = $col;
        }
    }
}
echo $matrix[$biggestIndex[0]][$biggestIndex[1]] . " " . $matrix[$biggestIndex[0]][$biggestIndex[1] + 1] . PHP_EOL;
echo $matrix[$biggestIndex[0] + 1][$biggestIndex[1]] . " " . $matrix[$biggestIndex[0] + 1][$biggestIndex[1] + 1] . PHP_EOL;
echo $biggestSum;