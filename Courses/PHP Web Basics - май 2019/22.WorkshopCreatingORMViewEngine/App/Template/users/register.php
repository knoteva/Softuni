<h2>Register Form</h2>
<form method="post">
    <label>
        Username: <input name="username" type="text"/>
    </label>
    <br><br>
    <label>
        Password: <input type="password" name="password"/>
    </label>
    <br><br>
    <label>
        Confirm Password:  <input type="password" name="confirm_password"/>
    </label>
    <br><br>
    <label>
        First Name: <input type="text" name="first_name"/>
    </label>
    <br><br>
    <label>
        Last Name: <input type="text" name="last_name"/>
    </label>
    <br><br>
    <label>
        Born on: <input type="date" name="born_on" min = "1919-01-01" max = "2009-01-01" value="2000-08-07"/>
    </label>
    <input type="submit" name="register" value="Register"/>
</form>

<br/>
You can go to <a href="index.php">home</a>