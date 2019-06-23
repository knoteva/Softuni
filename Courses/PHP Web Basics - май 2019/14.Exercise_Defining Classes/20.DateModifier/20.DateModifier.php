<?php
//class DateModifier
//{
//    public function calculateDayDifference(string $dateFrom, string $dateTo) : int
//    {
//        $datetime1 = new DateTime($dateFrom);
//
//        $datetime2 = new DateTime($dateTo);
//
//        $difference = $datetime1->diff($datetime2);
//        return $difference->d;
//    }
//}


$date1 = new DateTime("1992-05-31");

$date2 = new DateTime("2016-06-17");


echo $diff = $date2->diff($date1)->format("%a");