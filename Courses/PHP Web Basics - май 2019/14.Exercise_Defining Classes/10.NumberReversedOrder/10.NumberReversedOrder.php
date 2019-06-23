<?php

class DecimalNumber
{
    /**
     * @var string
     */
    private $number;

    public function __construct(string $number)
    {
        $this->number = $number;
    }

    public function reverseNumber() : string
    {
        return strrev($this->number);
    }
}

$number = new DecimalNumber(readline());

echo $number->reverseNumber();