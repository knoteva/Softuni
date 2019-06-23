<?php


class FoodFactory
{
    /**
     * @var string
     */
    private $points;

    public function __construct(string $food)
    {
        $this->setPoints($food);
    }

    public function getPoints() : string
    {
        return $this->points;
    }

    public function setPoints($food){
        if ($food == "cram"){
            $this->points = 2;
        }elseif ($food == "lembas"){
            $this->points = 3;
        }elseif ($food == "apple"){
            $this->points = 1;
        }elseif ($food == "melon"){
            $this->points = 1;
        }elseif ($food == "honeycake"){
            $this->points = 5;
        }elseif ($food == "mushrooms"){
            $this->points = -10;
        }else{
            $this->points = -1;
        }
    }
}


class MoodFactory
{
    /**
     * @var string
     */
    private $mood;
    public function __construct(int $points)
    {
        $this->setMood($points);
    }
    public function getMood() : string
    {
        return $this->mood;
    }
    public function setMood($points)
    {
        if ($points < -5){
            $this->mood = "Angry";
        }elseif ($points < 0){
            $this->mood = "Sad";
        }elseif ($points < 15){
            $this->mood = "Happy";
        }else{
            $this->mood = "PHP";
        }
    }
}


$allFood = explode(',', strtolower(readline()));
$totalPoints = 0;
foreach ($allFood as $food){
    $food = new FoodFactory($food);
    $totalPoints += $food->getPoints();
}
$mood = new MoodFactory($totalPoints);
echo $totalPoints . "\n";
echo $mood->getMood();