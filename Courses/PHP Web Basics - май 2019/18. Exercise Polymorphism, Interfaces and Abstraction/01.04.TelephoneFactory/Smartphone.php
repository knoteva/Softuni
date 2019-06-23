<?php

include_once "BrowsInterface.php";
include_once "CallInterface.php";

class Smartphone implements CallInterface, BrowsInterface
{

    /**
     * @param string $url
     * @return string
     * @throws \Exception
     */
    public function browse(string $url): string
    {
        if (preg_match("/\\d/", $url)) {
            throw new \Exception("Invalid URL!");
        }
        return "Browsing: {$url}!";
    }
    /**
     * @param string $number
     * @return string
     * @throws \Exception
     */
    public function call(string $number): string
    {
        if (!preg_match("/^[\\d]+$/", $number)) {
            throw new \Exception("Invalid number!");
        }
        return "Calling... {$number}";
    }
}