<?php


class Human
{
    /**
     * @var string
     */
    private $firstName;
    /**
     * @var string
     */
    private $lastName;

    /**
     * Human constructor.
     * @param string $firstName
     * @param string $lastName
     * @throws Exception
     */
    public function __construct(string $firstName, string $lastName)
    {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
    }

    /**
     * @return string
     */
    public function getFirstName(): string
    {
        return $this->firstName;
    }

    /**
     * @param string $firstName
     * @throws Exception
     */
    protected function setFirstName(string $firstName): void
    {
        if (!ctype_upper($firstName[0])) {
            throw new Exception("Expected upper case letter!Argument: firstName");
        } else if (strlen($firstName) < 4) {
            throw new Exception("Expected length at least 4 symbols!Argument: firstName");
        }
        $this->firstName = $firstName;
    }

    /**
     * @return string
     */
    public function getLastName(): string
    {
        return $this->lastName;
    }

    /**
     * @param string $lastName
     */
    protected function setLastName(string $lastName): void
    {
        if (!ctype_upper($lastName[0])) {
            throw new Exception("Expected upper case letter!Argument: firstName");
        } else if (strlen($lastName) < 3) {
            throw new Exception("Expected length at least 4 symbols!Argument: firstName");
        }
        $this->lastName = $lastName;
    }

}


class Student extends Human
{
    /**
     * @var string
     */
    private $facultyNumber;
    public function __construct(string $firstName, string $lastName, string $facultyNumber)
    {
        parent::__construct($firstName, $lastName);
        $this->setFacultyNumber($facultyNumber);

    }

    /**
     * @return string
     */
    public function getFacultyNumber(): string
    {
        return $this->facultyNumber;
    }

    /**
     * @param string $facultyNumber
     * @throws Exception
     */
    private function setFacultyNumber(string $facultyNumber): void
    {
        if (strlen($facultyNumber) < 5 || strlen($facultyNumber) > 10) {
            throw new \Exception("Invalid faculty number!");
        }

        $this->facultyNumber = $facultyNumber;
    }

    /**
     * @return string
     */
    public function __toString()
    {
        return "First Name: " . $this->getFirstName().PHP_EOL."Last Name: " . $this->getLastName().PHP_EOL."Faculty number: " . $this->getFacultyNumber().PHP_EOL.PHP_EOL;
        //First Name: {student's first name}
        //Last Name: {student's last name}
        //Faculty number: {student's faculty number}

    }
}

class Worker extends Human
{
    /**
     * @var float
     */
    private $weekSalary;
    /**
     * @var float
     */
    private $hoursPerDay;

    public function __construct(string $firstName, string $lastName, float $weekSalary, float $hoursPerDay)
    {
        parent::__construct($firstName, $lastName);
        $this->setWeekSalary($weekSalary);
        $this->setHoursPerDay($hoursPerDay);
    }

    /**
     * @return float
     */
    public function getWeekSalary(): float
    {
        return $this->weekSalary;
    }

    /**
     * @param float $weekSalary
     */
    public function setWeekSalary(float $weekSalary): void
    {
        if ($weekSalary < 10) {
            throw new \Exception("Expected value mismatch!Argument: weekSalary");
        }
        $this->weekSalary = $weekSalary;
    }

    /**
     * @return float
     */
    public function getHoursPerDay(): float
    {
        return $this->hoursPerDay;
    }

    /**
     * @param float $hoursPerDay
     * @throws Exception
     */
    public function setHoursPerDay(float $hoursPerDay): void
    {
        if ($hoursPerDay < 1 || $hoursPerDay > 12) {
            throw new \Exception("Expected value mismatch!Argument: workHoursPerDay");
        }

        $this->hoursPerDay = $hoursPerDay;
    }
    const dayOfWeek = 7;
    /**
     * @return float
     */
    public function getSalaryPerHour() : float{
        //TO DO. Maybe we need setter, field and constructor?
        return number_format($this->getWeekSalary() / ($this->getHoursPerDay() * self::dayOfWeek), 2,'.', '');
    }

    public function __toString()
    {
        return "First Name: " . $this->getFirstName().PHP_EOL."Last Name: " . $this->getLastName().PHP_EOL.
            "Week Salary: " . number_format($this->getWeekSalary(), 2, '.','').PHP_EOL
            ."Hours per day: " . number_format($this->getHoursPerDay(),2, '.','').PHP_EOL
            ."Salary per hour: " . $this->getSalaryPerHour().PHP_EOL;

//        First Name: {worker's first name}
//        Last Name: {worker's second name}
//        Week Salary: {worker's salary}
//        Hours per day: {worker's working hours}
//        Salary per hour: {worker's salary per hour}
    }
}

//$studentLine = explode(" ", 'Afo Mk321 0812111');
$studentLine = explode(" ", readline());

list($studentFirstName, $studentLastName, $studentFacultyNumber) = $studentLine;

try {
    $student = new Student($studentFirstName, $studentLastName, $studentFacultyNumber);
} catch(Exception $ex) {
    echo $ex->getMessage();
    return;
}
//$workerLine = explode(" ", 'Ivcho Ivancov 1590 10');
$workerLine = explode(" ", readline());
try {
    $worker = new Worker($workerLine[0], $workerLine[1], $workerLine[2], $workerLine[3]);

} catch(Exception $ex) {
    echo $ex->getMessage();
    return;
}
$worker = new Worker($workerLine[0], $workerLine[1], $workerLine[2], $workerLine[3]);

echo $student;
echo $worker;
