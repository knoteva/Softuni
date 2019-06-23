<?php


interface BirthdayInterface
{
    public function getBirthday() : string;
}

interface BuyerInterface
{
    public function getFood();
}


interface IdentifiableInterface
{
    public function getId() : string;
}

class Citizen implements IdentifiableInterface, BirthdayInterface, BuyerInterface
{

    private $name;
    private $age;
    private $id;
    private $birthday;
    private $food = 0;


    public function __construct(string $name, int $age, string $id, string $birthday)
    {
        $this->name = $name;
        $this->age = $age;
        $this->id = $id;
        $this->birthday = $birthday;
    }


    public function getName(): string
    {
        return $this->name;
    }

    public function getId(): string
    {
        return $this->id;
    }

    public function getBirthday(): string
    {
        return $this->birthday;
    }

    public function BuyFood()
    {
        $this->setFood($this->getFood() + 10);
    }
    public function getFood(): int
    {
        return $this->food;
    }
    public function setFood(int $value)
    {
        $this->food = $value;
    }
}

class Pet implements BirthdayInterface
{

    private $name;
    private $birthday;
    public function __construct(string $name, string $birthday)
    {
        $this->name = $name;
        $this->birthday = $birthday;
    }

    public function getBirthday(): string
    {
        return $this->birthday;
    }
}

class Rebel implements BuyerInterface
{
    private $name;
    private $age;
    private $group;
    private $food = 0;

    public function __construct(string $name, int $age, string $group)
    {
        $this->name = $name;
        $this->age = $age;
        $this->group = $group;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function BuyFood()
    {
        $this->setFood($this->getFood() + 5);
    }
    public function getFood(): int
    {
        return $this->food;
    }
    public function setFood(int $value)
    {
        $this->food = $value;
    }
}

class Robot implements IdentifiableInterface
{

    private $id;
    private $model;

    public function __construct(string $model, string $id)
    {
        $this->model = $model;
        $this->id = $id;
    }

    public function getId(): string
    {
        return $this->id;
    }

}

/**
 * @var $people BuyerInterface[]
 */
$people = [];
$numOfPeople = intval(readLine());

while ($numOfPeople) {
    $numOfPeople--;
    $tokens = explode(" ", readLine());
    if (count($tokens) === 4) {
        $people[$tokens[0]] = new Citizen($tokens[0], intval($tokens[1]), $tokens[2], $tokens[3]);
        continue;
    }
    if (count($tokens) === 3) {
        $people[$tokens[0]] = new Rebel($tokens[0], intval($tokens[1]), $tokens[2]);
    }
}
while (true) {
    $name = readLine();
    if ($name == "End") {
        break;
    }
    if (!array_key_exists($name, $people)) {
        continue;
    }
    $person = $people[$name];
    $person->buyFood();
}

$totalFood = 0;
foreach ($people as $person) {
    $totalFood += $person->getFood();
}
writeLine("{$totalFood}");

function writeLine($content)
{
    echo $content . PHP_EOL;
}