<?php


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