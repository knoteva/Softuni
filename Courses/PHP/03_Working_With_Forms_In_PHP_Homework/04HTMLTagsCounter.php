<?php
session_start();
$tags = ['!DOCTYPE', 'a', 'abbr', 'address', 'area', 'article', 'aside', 'audio', 'b', 'base', 'bdi', 'bdo',
'blockquote', 'body', 'br','button', 'canvas', 'caption', 'cite', 'code', 'col', 'colgroup', 'command', 'datalist',
'dd', 'del', 'details','dfn', 'div', 'dl', 'dt', 'em', 'embed', 'fieldset', 'figcaption', 'figure', 'footer', 'form',
'h1 - h6', 'head','header', 'hgroup', 'hr', 'html', 'i', 'iframe', 'img', 'input', 'ins', 'kbd', 'keygen', 'label',
'legend', 'li', 'link','map', 'mark', 'menu', 'meta', 'meter', 'nav', 'noscript', 'object', 'ol', 'optgroup', 'option',
'output', 'p', 'param', 'pre','progress', 'q', 'rp', 'rt', 'ruby', 's', 'samp', 'script', 'section', 'select', 'small',
'source', 'span','strong', 'style', 'sub', 'summary', 'sup', 'table', 'tbody', 'td', 'textarea', 'tfoot', 'th', 'thead',
'time', 'title','tr', 'track', 'u', 'ul', 'var', 'video', 'wbr'];
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Tags counter</title>
        <style>
            label {
                display: block;
                padding: 10px;
            }
        </style>
    </head>
    <body>
    <form action="04HTMLTagsCounter.php" method="post">
        <label for="input">Enter HTML Tags</label>
        <input type="text" name="input"/>
        <input type="submit" value="submit"/>
    </form>

        <?php
        if (isset($_POST['input'])) {
            $tag = htmlentities($_POST['input']);
            if (in_array($tag, $tags)) {
                echo 'Valid HTML Tag!' ."<br>";
                $_SESSION['count']++;
            } else {
                echo 'Invalid HTML Tag!' ."<br>";
                $_SESSION['count'] = 0;
            }
            echo 'Score: ' . $_SESSION['count'];
        }
        //session_unset();
        ?>

    </body>
</html>