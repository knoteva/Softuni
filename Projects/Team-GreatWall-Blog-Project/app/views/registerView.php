<?php require_once '../app/incl/header-tiny.php'; ?> 

    <main class="main container row">
        <section class="twelve columns">
            <div class="register-container">
                <?php
                if (!empty ($data)) {
                    foreach ( $data as $d) {
                        echo $d;
                    }
                }
                ?>
                <h3>Register: </h3>
                <form action="" method="POST">
                    <input type="text" name="username" placeholder="Username" /><br />
                    <input type="text" name="firstname" placeholder="Firstname" /><br />
                    <input type="text" name="lastname" placeholder="Lastname" /><br />
                    <input type="password" name="password" placeholder="Password" /><br />
                    <input type="email" name="email" placeholder="Email"><br />
                    <input type="submit" name="registerSubmit" value="C'mon" />
                </form>
            </div>
        </section>
    </main>
    
<?php require_once '../app/incl/footer.php'; ?>