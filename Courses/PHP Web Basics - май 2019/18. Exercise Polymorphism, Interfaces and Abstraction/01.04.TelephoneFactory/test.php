<?php


interface BrowsInterface
{
    public function browse(string $url): string;
}


interface CallInterface
{
    public function call(string $number): string;

}


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


$phone = new SmartPhone();
$phoneNumbers = explode(" ", readLine());
$websites = explode(" ", readLine());


foreach ($phoneNumbers as $phoneNumber) {
    try {
        echo $phone->call($phoneNumber).PHP_EOL;
    } catch (Exception $ex) {
        echo $ex->getMessage().PHP_EOL;
    }
}
foreach ($websites as $website) {
    try {
        echo $phone->browse($website).PHP_EOL;
    } catch (Exception $ex) {
        echo $ex->getMessage().PHP_EOL;
    }
}