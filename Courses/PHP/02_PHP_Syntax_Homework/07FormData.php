<!doctype html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Form Data</title>
        <style>
            input[type="text"], input[type="submit"]{
                display: block;
                margin-top: 5px;
            }
        </style>
    </head>
    <body>
        <form method="get" action="07FormData.php">
            <input type="text" name="firstName" placeholder="Name..." required="required" />
            <input type="text" name="age" placeholder="Age..." required="required" />
            <input type="radio" name="gender" value="male" required="required" /> Male <br />
            <input type="radio" name="gender" value="female" required="required" /> Female <br />
            <input type="submit" value="Submit" />
        </form>

    <?php if (isset($_GET["firstName"], $_GET["age"], $_GET["gender"] )): ?>
        <p>My name is <?= htmlspecialchars($_GET['firstName'])?>. I am <?= htmlspecialchars($_GET["age"])?> years old. I am <?= htmlspecialchars($_GET["gender"])?>.</p>
    <?php endif ?>
    </body>
</html>