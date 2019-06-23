<?php

require_once "Book.php";

class GoldenEditionBook extends Book
{
        public function getPrice(): float
    {
        return parent:: getPrice() * 1.3;
    }
}