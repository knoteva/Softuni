<?php /**@var \App\Data\UserDTO $data */ ?>

<h2>Your profile</h2>
<form method="post">
    <label>
        Username: <input name="username" type="text" value="<?= $data-> getUsername()?>"/>
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
        First Name: <input type="text" name="first_name" value="<?= $data-> getFirstName()?>"/>
    </label>
    <br><br>
    <label>
        Last Name: <input type="text" name="last_name" value="<?= $data-> getLastName()?>"/>
    </label>
    <br><br>
    <label>
        Born on: <input type="date" name="born_on" min = "1919-01-01" max = "2009-01-01" value="2000-08-07" value="<?= $data-> getBornOn()?>"/>
    </label>
    <input type="submit" name="edit" value="Save"/>
</form>

<br/>

You can <a href="logout.php">logout</a> or see <a href="all.php">all users</a>