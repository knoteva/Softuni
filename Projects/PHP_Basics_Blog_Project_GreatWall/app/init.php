<?php
session_start();

require_once '../app/base/App.php';
require_once '../app/base/Config.php';

$app = App::getInstance();
$app->autoLoad();
$app->run();	