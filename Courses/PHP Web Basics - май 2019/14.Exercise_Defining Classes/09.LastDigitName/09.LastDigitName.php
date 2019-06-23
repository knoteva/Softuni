<?php

class LastDigitName
{
    /**
     * @var int
     */
    private $number;

    /**
     * LastDigitName constructor.
     * @param int $number
     */
    public function __construct(int $number)
    {
        $this->number = $number;
    }

    public function getNumber(): int
    {
        return $this->number;
    }

    public function lastDigitName()
    {
        $num = $this->number % 10;
        switch ($num) {
            case 0:
                return 'zero';
                break;
            case 1:
                return 'one';
                break;
            case 2:
                return 'two';
                break;
            case 3:
                return 'three';
                break;
            case 4:
                return 'four';
                break;
            case 5:
                return 'five';
                break;
            case 6:
                return 'six';
                break;
            case 7:
                return 'seven';
                break;
            case 8:
                return 'eight';
                break;
            case 9:
                return 'nine';
                break;
        }
        return $num;
    }
}
$number = new LastDigitName( intval(readline()));
echo $number->lastDigitName();
