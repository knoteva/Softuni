<?php


interface CarInterface
{
    public function brakes();
    public function gas();
}


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


    public function brakes()
    {
        return "Brakes!";
    }

    public function gas()
    {
        return "Zadu6avam sA!";
    }
    function __toString()
    {
        return "{$this->model}/" . $this->brakes() . "/" . $this->gas() . "/{$this->driverName}";
    }
}



$person = trim(fgets(STDIN));
$ferrari = new Ferrari($person);
echo $ferrari;