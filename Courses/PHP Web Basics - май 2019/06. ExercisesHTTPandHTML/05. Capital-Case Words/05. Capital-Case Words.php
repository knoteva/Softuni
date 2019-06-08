
<form>
    <textarea rows="10" name="text"></textarea><br>
    <input type="submit" value="Extract">
</form>

<?php

if(isset($_GET['text'])) {
   $input = array_filter(array_map('trim', preg_split( "/[^A-Za-z]/", $_GET['text'] )));
//$input = array_filter(array_map('trim', preg_split( "/[\n \r , . ]/", 'd ASP.NET MVC.
//Finally, we touch some Java, Hibernate and Spring.MVC.')));


//    sort($input, SORT_STRING);
//    $sortedLines = implode("\n", $input);

    foreach ($input as $word) {
       // $word = preg_replace('/[^A-Za-z\d ]/i', '', $word);
        if (ctype_upper($word)) {
        echo $word.PHP_EOL;
        }
    }
    //preg_match_all("/[[:upper:]]+/u", $input, $matches);
    //var_dump($matches);
}
