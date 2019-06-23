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
    public function setDough(Dough $dough): void
    {
        $this->dough = $dough;
    }

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


class Dough
{
    const CALORIES_PER_GRAM = 2;
    const DOUGH_TYPES = [
        "white" => 1.5,
        "wholegrain" => 1.0
    ];
    const BAKING_TECHNIQUES = [
        "crispy" => .9,
        "chewy" => 1.1,
        "homemade" => 1.0
    ];
    /**
     * @var string
     */
    private $type;
    /**
     * @var string
     */
    private $bakingTechnique;
    /**
     * @var int
     */
    private $weight;

    /**
     * Dough constructor.
     * @param string $type
     * @param string $bakingTechnique
     * @param int $weight
     * @throws Exception
     */
    public function __construct(string $type, string $bakingTechnique, int $weight)
    {
        $this->setType($type);
        $this->setBakingTechnique($bakingTechnique);
        $this->setWeight($weight);
    }

    /**
     * @param string $type
     * @throws Exception
     */
    public function setType(string $type): void
    {
        if (!array_key_exists($type, self::DOUGH_TYPES)) {
            throw new \Exception("Invalid type of dough.");
        }
        $this->type = $type;
    }

    /**
     * @param string $bakingTechnique
     */
    public function setBakingTechnique(string $bakingTechnique): void
    {
        $this->bakingTechnique = $bakingTechnique;
    }

    /**
     * @param int $weight
     * @throws Exception
     */
    public function setWeight(int $weight): void
    {
        if ($weight < 1 || $weight > 200) {
            throw new \Exception("Dough weight should be in the range [1..200].");
        }
        $this->weight = $weight;
    }
    public function getCalories() : float {
        return $this->weight
            * self:: CALORIES_PER_GRAM
            * self:: DOUGH_TYPES[$this->type]
            * self:: BAKING_TECHNIQUES[$this->bakingTechnique];
    }
}


class Topping
{
    const CALORIES_PER_GRAM = 2;
    const TOPPING_TYPES =
        [
            "meat" => 1.2,
            "veggies" => 0.8,
            "cheese" => 1.1,
            "sauce" => 0.9
        ];
    /**
     * @var string
     */
    private $type;
    /**
     * @var int
     */
    private $weight;

    /**
     * Topping constructor.
     * @param string $type
     * @param int $weight
     * @throws Exception
     */
    public function __construct(string $type, int $weight)
    {
        $this->setType($type);
        $this->setWeight($weight);
    }

    /**
     * @param string $type
     * @throws Exception
     */
    protected function setType(string $type): void
    {
        if (!array_key_exists($type, self::TOPPING_TYPES)) {
            $type[0] = strtoupper($type[0]);
            throw new Exception("Cannot place {$type} on top of your pizza.");
        }
        $this->type = $type;
    }

    /**
     * @param int $weight
     * @throws Exception
     */
    protected function setWeight(int $weight): void
    {
        if ($weight < 1 || $weight > 50) {
            $this->type[0] = strtoupper($this->type[0]);
            throw new Exception("{$this->type} weight should be in the range [1..50].");
        }
        $this->weight = $weight;
    }

    public function getCalories()
    {
        return $this->weight
            * self::CALORIES_PER_GRAM
            *self::TOPPING_TYPES[$this->type];
    }
}

//$pizzaTokens = explode(" ", "Pizza Meatfull 5");
$pizzaTokens = explode(" ", readLine());
try {
    $pizza = new Pizza(strtolower($pizzaTokens[1]), intval($pizzaTokens[2]));
} catch (Exception $ex) {
    echo $ex->getMessage();
    return;
}
//$doughTokens = explode(" ", "Dough White cheWy 200");
$doughTokens = explode(" ", readLine());
try {
    $dough = new Dough(strtolower($doughTokens[1]), strtolower($doughTokens[2]), $doughTokens[3]);
} catch (Exception $ex) {
    echo $ex->getMessage();
    return;
}
$pizza->setDough($dough);

while (true) {
    //$toppingData = explode(" ", "Topping Meat 50");
    $toppingData = explode(" ", readline());
    if ($toppingData[0] === "END") {
        break;
    }
    try {
        $topping = new Topping(strtolower($toppingData[1]), intval($toppingData[2]));

    } catch (Exception $ex) {
        echo $ex->getMessage();
        return;
    }
    $pizza->addTopping($topping);
}


echo $pizza;