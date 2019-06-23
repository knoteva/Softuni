<?php
$db = new PDO('mysql:dbname=php_web_test;host=localhost', 'root', '123+');
?>
<form>
    Username:<input type="text" name="username"/><br/>
    Pass:<input type="text" name="password"/><br/>
    <input type="submit"/>
</form>
<?php
if (isset($_POST['username'], $_POST['password'])) {

    $username = $_POST['username'];
    $password = $_POST['password'];
    $querry = "
        INSERT INTO
         users (
            username,
            password
         )
         VALUES (
            '$username',
            '$password'
         ) 
    ";
    echo $querry;
}