<?php


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