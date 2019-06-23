<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Register Form</title>
    <link rel="stylesheet" href="templates/styles/style.css"/>
</head>
<body>
<form method ="post">
    Username:<input type="text" name="username"/><br/>
    Pass:<input type="password" name="password"/><br/>
    <input type="submit"/>
</form>
<div id="response">
    <?= $response; ?>
</div>
</body>
</html>