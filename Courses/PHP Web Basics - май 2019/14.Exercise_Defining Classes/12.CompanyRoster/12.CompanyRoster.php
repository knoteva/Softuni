<?php
class Employee
{
    private $name;
    private $salary;
    private $position;
    private $department;
    private $email;
    private $age;
    public function __construct($name, $salary, $position, $department, $email = 'n/a', $age = -1)
    {
        $this->name = $name;
        $this->salary = $salary;
        $this->position = $position;
        $this->department = $department;
        $this->email = $email;
        $this->age = $age;
    }
    public function __toString()
    {
        return sprintf("$this->name %.2f $this->email $this->age", $this->salary);
    }
    public function getName()
    {
        return $this->name;
    }
    public function setName($name): void
    {
        $this->name = $name;
    }
    public function getSalary()
    {
        return $this->salary;
    }
    public function setSalary($salary): void
    {
        $this->salary = $salary;
    }
    public function getPosition()
    {
        return $this->position;
    }
    public function setPosition($position): void
    {
        $this->position = $position;
    }
    public function getDepartment()
    {
        return $this->department;
    }
    public function setDepartment($department): void
    {
        $this->department = $department;
    }
    public function getEmail()
    {
        return $this->email;
    }
    public function setEmail($email): void
    {
        $this->email = $email;
    }
    public function getAge()
    {
        return $this->age;
    }
    public function setAge($age): void
    {
        $this->age = $age;
    }
}
$employees = [];
$departments = [];
$n = intval(readline());
while ($n-- > 0) {
    $tokens = explode(' ', readline());
    $name = $tokens[0];
    $salary = round(floatval($tokens[1]),2);
    $position = $tokens[2];
    $department = $tokens[3];
    $email = null;
    $age = null;
    if (count($tokens) === 6) {
        $email = $tokens[4];
        $age = intval($tokens[5]);
        $employee = new Employee($name, $salary, $position, $department, $email, $age);
        $employees[] = $employee;
        if (!array_key_exists($department, $departments)) {
            $departments[$department] = [];
        }
        $departments[$department][] = $salary;
        continue;
    }
    if (count($tokens) === 5) {
        if (is_numeric($tokens[4])) {
            $age = intval($tokens[4]);
            $employee = new Employee($name, $salary, $position, $department, 'n/a', $age);
            $employees[] = $employee;
            if (!array_key_exists($department, $departments)) {
                $departments[$department] = [];
            }
            $departments[$department][] = $salary;
        } else {
            $email = $tokens[4];
            $employee = new Employee($name, $salary, $position, $department, $email);
            $employees[] = $employee;
            if (!array_key_exists($department, $departments)) {
                $departments[$department] = [];
            }
            $departments[$department][] = $salary;
        }
        continue;
    }
    if (count($tokens) === 4) {
        $employee = new Employee($name, $salary, $position, $department);
        $employees[] = $employee;
        if (!array_key_exists($department, $departments)) {
            $departments[$department] = [];
        }
        $departments[$department][] = $salary;
    }
}
uasort($departments, function ($x1, $x2) {
    return array_sum($x2) / count($x2) <=> array_sum($x1) / count($x1);
});
$best_department = key($departments);
uasort($employees, function (Employee $e1, Employee $e2) {
    return $e2->getSalary() <=> $e1->getSalary();
});
echo "Highest Average Salary: $best_department" . PHP_EOL;
foreach ($employees as $employee) {
    if (count($departments) > 1){
        if ($employee->getDepartment() === $best_department) {
            echo $employee . PHP_EOL;
        }
    }else{
        echo $employee . PHP_EOL;
    }

}