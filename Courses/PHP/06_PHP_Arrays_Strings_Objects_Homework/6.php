<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>URL Replacer</title>
</head>
<body>
<form method="POST" action="Problem%2006.%20URLRaplace.php">
    <textarea name="text"></textarea>
    <input type="submit" name="submit" value="Submit">
</form>
<br>
<?php
if (isset($_POST['text'])) {
    $text = $_POST['text'];
    $aTagsCount = preg_match_all('/(?i)<a\s*href\s*=\s*([^>]+)>(.+?)<\/a>/', $text, $aTags);
    for ($i = 0; $i < count($aTags[0]); $i++) {
        $url = substr($aTags[1][$i], 1, strlen($aTags[1][$i]) - 2);
        $textBetweenATag = $aTags[2][$i];
        $replacement = "[URL=" . $url . "]" . $textBetweenATag. "[/URL]";
        $text = str_replace($aTags[0][$i], $replacement, $text);
    }
    echo htmlentities($text);
}
?>
</body>
</html>