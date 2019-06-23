<?php

include_once "Song.php";
include_once "PlayList.php";


//$count = 1;
$count = intval(readline());

/**
 * @var $playList Playlist
 */

$playList = new PlayList();

for ($i = 0; $i < $count; $i++) {
    //$line = preg_split("/[;:]/", "Nasko Mentata;Shopskata salata;0:5", - 1, PREG_SPLIT_NO_EMPTY);
    $line = preg_split("/[;:]/", readline(), - 1, PREG_SPLIT_NO_EMPTY);
    list($artist, $title, $minutes, $seconds) = $line;
    $minutes = intval($minutes);
    $seconds = intval($seconds);
    try {
        $song = new Song($artist, $title, $minutes, $seconds);
        $playList->AddMedia($song);
        //print_r($playList);
        echo "Song added.".PHP_EOL;
    } catch(Exception $ex) {
        echo $ex->getMessage();
    }
}
echo $playList;