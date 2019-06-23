<?php


interface Birthable
{
    public function getBirthdate() : string;
    public function setBirthdate(string $birthDate );
}