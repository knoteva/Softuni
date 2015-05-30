<?php require_once '../app/incl/header-tiny.php'; ?>
    <main class="main container row">
        <section class="twelve columns">
            <div class="login-container">
                <?php
                if (!empty ($data)) {
                    echo $data[0];
                }
                ?>
                <h3>Login: </h3>
                <form action="" method="POST">
                    <input type="text" name="username" placeholder="Username" /> <br />
                    <input type="password" name="password" placeholder="Password" /> <br />
                    <input type="submit" name="loginSubmit" value="Login" />
                </form>
            </div>
        </section>
    </main>
    
<?php require_once '../app/incl/footer.php'; ?>



