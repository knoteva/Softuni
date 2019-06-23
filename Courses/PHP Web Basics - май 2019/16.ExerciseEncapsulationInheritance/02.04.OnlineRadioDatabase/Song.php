<?php


class Song
{
    /**
     * @var string
     */
    private $artist;
    /**
     * @var string
     */
    private $title;
    /**
     * @var int
     */
    private $duration;

    /**
     * Song constructor.
     * @param string $artist
     * @param string $title
     * @param int $duration
     * @throws Exception
     */
    public function __construct(string $artist, string $title, int $minutes, int $seconds)
    {
        $this->setArtist($artist);
        $this->setTitle($title);
        $this->setDuration($minutes, $seconds);
    }

    /**
     * @return string
     */
    public function getArtist(): string
    {
        return $this->artist;
    }

    /**
     * @param string $artist
     * @throws Exception
     */
    protected function setArtist(string $artist): void
    {
        if (strlen($artist) < 3 || strlen($artist) > 20) {
            throw new Exception("Artist name should be between 3 and 20 symbols.".PHP_EOL);
        }
        $this->artist = $artist;
    }

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
        if (strlen($title) < 3 || strlen($title) > 30) {
            throw new Exception("Song name should be between 3 and 30 symbols.".PHP_EOL);
        }
        $this->title = $title;
    }

    /**
     * @return int
     */
    public function getDuration(): int
    {
        return $this->duration;
    }

    /**
     * @param int $duration
     * @throws Exception
     */
    protected function setDuration(int $minutes, int $seconds): void
    {
        if ($minutes< 0 || $minutes > 14) {
            throw new Exception("Song minutes should be between 0 and 14.".PHP_EOL);
        }
        if ($seconds < 0 || $seconds > 59) {
            throw new Exception("Song seconds should be between 0 and 59.".PHP_EOL);
        }
        $this->duration = $seconds + $minutes * 60;
    }

}