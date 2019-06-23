<?php

namespace App\Http;

use Core\TemplateInterface;

abstract class UserHttpHandlerAbstract
{
    /**
     * @var TemplateInterface
     */
    private $template;

    /**
     * UserHttpHandlerAbstract constructor.
     * @param TemplateInterface $template
     */
    public function __construct(TemplateInterface $template)
    {
        $this->template = $template;
    }

    public function rendler(string $templateName, $data = null) : void
    {
        $this->template->render($templateName, $data);
    }

    public function redirect(string $url) : void
    {
        header("Location: $url");
    }

}