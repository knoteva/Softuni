
<form>
    <textarea name="input"></textarea><br>
    <input type="submit" value="Count words">
</form>

<?php
if (isset($_GET['input'])) {
    $input = htmlspecialchars($_GET['input']);
    $data = preg_split('/[^A-Za-z]+/', $input, -1, PREG_SPLIT_NO_EMPTY);
    $wordsCount = [];
    foreach ($data as $currWord) {
        if (!key_exists(strtolower($currWord), $wordsCount)) {
            $wordsCount[strtolower($currWord)] = 1;
        } else {
            $wordsCount[strtolower($currWord)]++;
        }
    }

    $output = "<table border='2'>";

    foreach ($wordsCount as $word => $count) {
        $output .= "<tr><td>$word</td><td>$count</td></tr>";
    }

    $output .= "</table>";
    echo $output;
}