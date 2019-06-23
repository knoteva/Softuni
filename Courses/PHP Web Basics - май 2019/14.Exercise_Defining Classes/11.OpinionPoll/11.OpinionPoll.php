<?php

class Person
{
    /**
     * @var string
     */
    private $name;

    /**
     * @var int
     */
    private $age;

    /**
     * Person constructor.
     * @param string $name
     * @param int $age
     */
    public function __construct(string $name, int $age)
    {
        $this->name = $name;
        $this->age = $age;
    }
    public function __toString()
    {
        return "$this->name - $this->age".PHP_EOL;
    }

    /**
     * @return string
     */
    public function getName(): string
    {
        return $this->name;
    }

    /**
     * @return int
     */
    public function getAge(): int
    {
        return $this->age;
    }

}

$n = intval(readline());
$arr = [];

for ($i = 0; $i < $n; $i++) {
    list($name, $age) = explode(' ', readline());
    $currentPerson = new Person($name, $age);
    if ($currentPerson->getAge() > 30) {
    $arr[] = $currentPerson;
    }
}

uasort($arr, function($a, $b){
    return $a->getName() <=> $b->getName();
});
foreach ($arr as $person) {
    echo $person;
}


