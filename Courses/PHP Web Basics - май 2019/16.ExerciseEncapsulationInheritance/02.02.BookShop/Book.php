<?php


class Book
{
    /**
     * @var string
     */
    private $title;
    /**
     * @var array
     */
    private $author;
    /**
     * @var float
     */
    private $price;

    /**
     * Book constructor.
     * @param string $title
     * @param array $author
     * @param float $price
     * @throws Exception
     */
    public function __construct(string $title, array $author, float $price)
    {
        $this->setTitle($title);
        $this->setAuthor($author);
        $this->setPrice($price);
    }

    /**
     * Book constructor.
     * @param string $title
     * @param string $author
     * @param float $price
     */


    /**
     * @return string
     */
    public function getTitle(): string
    {
        return $this->title;
    }

    /**
     * @param string $title
     * @throws Exception
     */
    protected function setTitle(string $title): void
    {
        if(strlen($title) < 3){
            throw new Exception('Title not valid!'.PHP_EOL);
        }
        $this->title = $title;
    }

    /**
     * @return array
     */
    public function getAuthor(): array
    {
        return $this->author;
    }

    /**
     * @param string $author
     * @throws Exception
     */
    protected function setAuthor(array $author): void

    {
        if (count($author) > 1) {
            if (is_numeric(substr($author[1], 0, 1))) {
                throw new \Exception("Author not valid!");
            }
        }

        $this->author = $author;
    }

    /**
     * @return float
     */
    public function getPrice(): float
    {
        return $this->price;
    }

    /**
     * @param float $price
     * @throws Exception
     */
    protected function setPrice(float $price): void
    {
        if ($price <= 0) {
            throw new Exception("Price not valid!");
        }
        $this->price = $price;
    }
    public function __toString()
    {
        return "OK\n" . $this->getPrice();
    }

}