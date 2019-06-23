<?php

require_once "Human.php";

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