<?php
class Person{
    public $name;
    public $age;
}

$person = new Person();
echo(count(get_object_vars($person)));

//
//$person1 = new Person();
//$person1->name = "Pesho";
//$person1->age = 20;
//
//$person2 = new Person();
//$person2->name = "Gosho";
//$person2->age = 18;
//
//$person3 = new Person();
//$person3->name = "Stamat";
//$person3->age = 43;
//
//var_dump($person1);
//var_dump($person2);
//var_dump($person3);