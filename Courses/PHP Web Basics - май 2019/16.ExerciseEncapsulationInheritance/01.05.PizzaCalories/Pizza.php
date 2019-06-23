<?php


class Pizza
{
    /**
     * @var string
     */
    private $name;
    /**
     * @var int
     */
    private $numberOfToppings;
    /**
     * @var Dough $dough
     */
    private $dough;

    /**
     * @var Topping[] $toppings
     */
    private $toppings = [];

    /**
     * Pizza constructor.
     * @param string $name
     * @param int $numberOfToppings
     * @throws Exception
     */
    public function __construct(string $name, int $numberOfToppings)
    {
        $this->setName($name);
        $this->setNumberOfToppings($numberOfToppings);

    }

    /**
     * @return string
     */
    public function getName(): string
    {
        return $this->name;
    }

    /**
     * @param string $name
     * @throws Exception
     */
    public function setName(string $name): void
    {
        if (strlen($name) < 1 || strlen($name) > 15) {
            throw new Exception("Pizza name should be between 1 and 15 symbols.");
        }
        $this->name = $name;
    }

    /**
     * @param Dough $dough
     */


    /**
     * @return void $topping
     */

    public function addTopping(Topping $topping) : void
    {
        $this->toppings[] = $topping;
    }

    /**
     * @param $numberOfToppings
     * @throws Exception
     */
    public function setNumberOfToppings($numberOfToppings)
    {
        if ($numberOfToppings < 0 || $numberOfToppings > 10) {
            throw new \Exception("Number of toppings should be in range [0..10].");
        }
        $this->numberOfToppings = $numberOfToppings;
    }
    public function setDough(Dough $dough): void
    {
        $this->dough = $dough;
    }
    public function getTotalCalories() :float {
        $calories = $this->dough->getCalories();

            foreach ($this->toppings as $topping) {
                $calories += $topping->getCalories();
            }
            return $calories;
    }

    public function __toString()
    {
        $totalCalories = number_format($this->getTotalCalories(), 2, ".","");
        $this->name[0] = strtoupper($this->name[0]);
        return "{$this->name} - {$totalCalories} Calories.";
    }


}
