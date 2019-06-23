<?php

require_once "CarInterface.php";
class Ferrari implements CarInterface
{
    /**
     * @var string
     */
    private $driverName;
    /**
     * @var string
     */
    private $model;

    /**
     * Ferrari constructor.
     * @param string $driverName
     * @param string $model
     */
    public function __construct(string $driverName, string $model = "488-Spider")
    {
        $this->driverName = $driverName;
        $this->model = $model;
    }

    /**
     * @return string
     */
    public function getDriverName(): string
    {
        return $this->driverName;
    }


    public function brakes()
    {
        return "Brakes!";
    }

    public function gas()
    {
        return "Zadu6avam sA!";
    }

    static function forUrl(string $str, string $rep="-")
    {
        return  $str = str_replace (" ", $rep, $str);
    }

    function __toString()
    {
        return "{$this->model}/" . $this->brakes() . "/" . $this->gas() . "/{$this->driverName}";
    }
}