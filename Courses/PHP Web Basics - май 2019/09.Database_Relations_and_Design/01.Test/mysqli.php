<?php

$db = new mysqli('localhost', 'root', '123+', 'soft_uni');

$db->set_charset("utf8");
if ($db->connect_errno){
    die('Cannot connect to MySQL');
}else {
    echo "Connected";
}

$result = $db->query('select * FROM towns');

while ($row = $result->fetch_assoc()) {
    print_r($row);
}


