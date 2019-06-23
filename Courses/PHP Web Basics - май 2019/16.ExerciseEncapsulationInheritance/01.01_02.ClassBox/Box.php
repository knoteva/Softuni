<?php

class Box
{
    /**
     * @var float
     */
    private $length;
    /**
     * @var float
     */
    private $width;
    /**
     * @var float
     */
    private $height;

    /**
     * Box constructor.
     * @param float $length
     * @param float $width
     * @param float $height
     * @throws Exception
     */
    public function __construct(float $length, float $width, float $height)
    {
        $this->setLength($length);
        $this->setWidth($width);
        $this->setHeight($height);
    }

    /**
     * @return float
     */
    public function getLength(): float
    {
        return $this->length;
    }

    /**
     * @param float $length
     * @throws Exception
     */
    private function setLength(float $length): void
    {
        $this->validateInput($length, "Length");
        $this->length = $length;
    }

    /**
     * @return float
     */
    public function getWidth(): float
    {
        return $this->width;
    }

    /**
     * @param float $width
     * @throws Exception
     */
    private function setWidth(float $width): void
    {
        $this->validateInput($width, "Width");
        $this->width = $width;
    }

    /**
     * @return float
     */
    public function getHeight(): float
    {
        return $this->height;
    }

    /**
     * @param float $height
     * @throws Exception
     */
    private function setHeight(float $height): void
    {
        $this->validateInput($height, "Height");
        $this->height = $height;
    }

    private function surfaceArea() : float
    {
        return  2 * $this->getLength() * $this->getWidth() + 2 * $this->getLength() * $this->getHeight() + 2 * $this->getWidth() * $this->getHeight();
    }
    private function lateralSurfaceArea() : float
    {
        return 2 * $this->getLength() * $this->getHeight() + 2 * $this->width * $this->getHeight();
    }
    private function volume() : float
    {
        return $this->getLength() * $this->getWidth() *$this->getHeight();
    }

    /**
     * @param float $value
     * @param string $param
     * @throws Exception
     */
    private function validateInput(float $value, string $param) : void
    {
        if ($value <= 0) {
            throw new Exception("{$param} cannot be zero or negative.");
        }
    }
    public function __toString()
    {
        return "Surface Area - " . number_format($this->surfaceArea(), 2, ".", "").PHP_EOL
            ."Lateral Surface Area - " . number_format($this->lateralSurfaceArea(), 2, ".", "") . PHP_EOL
            . "Volume - " .number_format($this->volume(), 2, ".", "");

    }

}

