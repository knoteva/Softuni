<?php

date_default_timezone_set("Europe/Sofia");
$now = new DateTime();
//echo $now->format('Y-m-d H:i:s');

//$now = new DateTime('12-08-2014 13:07:09');
$newYear = new DateTime('31-12-2015 23:59:59');
//echo $newYear->format('Y-m-d H:i:s');

$days = $newYear->diff($now)->format("%a");
$hours = $newYear->diff($now)->format("%H");
$minutes = $newYear->diff($now)->format("%I");
$seconds = $newYear->diff($now)->format("%S");
$allHours = ($days * 24 + $hours);
$allMinutes = $allHours * 60 + $minutes;
$allSeconds = $allMinutes * 60 + $seconds;

echo "Hours until new year : " . $allHours . "\n";
echo "Minutes until new year : " . number_format($allMinutes, 0, ' ', ' ') . "\n";
echo "Seconds until new year : " . number_format($allSeconds, 0, ' ', ' ') . "\n";
echo "Days:Hours:Minutes:Seconds $days:$hours:$minutes:$seconds";

?>
