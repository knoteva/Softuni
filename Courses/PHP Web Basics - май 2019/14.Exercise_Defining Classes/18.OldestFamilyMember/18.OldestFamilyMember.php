<?php

//1. Създаваме клас Person
//2. Поле за име(name): string
//3. Поле за години(age): int
//4. Добавяме конструктор. Не трябва да променяме името и годините за това добавяме и гетъри.
//5. Създаваме клас Family
//6. Поле за членовете на семейството.  Масив от обекти тип Person
//7. Създаваме функция addMember(). Приема за параметър обект от тип Person и го добавя към масива от т.6 и не връща нищо(void)
//  7.1 При добавяне на член от фамилята да проверяваме дали не е по-стар от най-стария. Ако е да го заместим
//8. Създаваме функция getOldestMember(). Минава през масива от хора, проверява кой е най-стар и връща този обект (Person)
//9. Четем вход: Колко хора ще получим
//10. Четем толкова двойки име - години, колкото сме прочели в т.9
//11. Взимаме имената и годините и създаваме обект от тип Person, койтоп добавяме към обекта Family
//12. Принтираме името и годините на getOldestMember()

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
    public function __toString()
    {
        return $this->getName(). ' '.$this->getAge();
    }
}

class Family
{
    private $members;

    /**
     * @var Person
     */
    private $oldestMember;

    public function __construct()
    {
        $this->members = [];
        $this->oldestMember = null;
    }
    public function addMember(Person $person): void
    {
        if ($this->oldestMember === null || $this->oldestMember->getAge() < $person->getAge()) {
            $this->oldestMember = $person;
        }
        $this->members[] = $person;
    }
    public function getOldestMember(): ?Person
    {
        return $this->oldestMember;
    }
}

//$lines = 3;
$lines = intval(readline());
$family = new Family();
for ($i = 0; $i < $lines; $i++) {
    list($name, $age) = explode(' ', readline());
    $person  = new Person($name, $age);
    $family->addMember($person);
    //var_dump($person);
}
echo $family->getOldestMember();



