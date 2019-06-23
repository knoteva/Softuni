<?php

require_once "Human.php";

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