<?php

class Person{
    public $name;
    function __construct($name){
        $this->name = $name;
    }
    function __toString(){
        return "$this->name says \"Hello\"!";
    }
}

$person = new Person(readline());
echo $person;