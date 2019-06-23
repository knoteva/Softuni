<?php


interface IdentifiableInterface
{
    public function getId() : string;
}


interface BirthdayInterface
{
    public function getBirthday(): string;
}

class Citizen implements IdentifiableInterface, BirthdayInterface
{

    private $name;
    private $age;
    private $id;
    private $birthday;
    public function __construct(string $name, int $age, string $id, string $birthday)
    {
        $this->name = $name;
        $this->age = $age;
        $this->id = $id;
        $this->birthday = $birthday;
    }

    public function getId(): string
    {
        return $this->id;
    }

    public function getBirthday(): string
    {
        return $this->birthday;
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

//include_once "IdentifiableInterface.php";
/**
 * @var $entries BirthdayInterface[]
 */
$entries = [];
while (true) {
    //$tokens = explode(" ","Pet Topcho 24/12/2000");
    $tokens = explode(" ", readLine());
    if ($tokens[0] == "End") {
        break;
    }
    $type = array_shift($tokens);
    if ($type == "Citizen") {
        $entries[] = new Citizen($tokens[0], intval($tokens[1]), $tokens[2], $tokens[3]);
    } else if ($type == "Pet") {
        $entries[] = new Pet($tokens[0], $tokens[1]);
    }
}
$year = readline();
$count = 0;
foreach ($entries as $entry) {
    if (preg_match("/" . $year . "$/", $entry->getBirthday())) {
        writeLine($entry->getBirthday());
        $count++;
    }
}


if ($count === 0) {
    echo "<no output>";

}
function writeLine($content)
{
    echo $content . PHP_EOL;
}