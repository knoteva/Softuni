<?php require_once '../app/incl/header-tiny.php'; ?> 

    <main class="main container row">
        <section class="eight columns">
            <?php echo $data[0]; ?>
            <?php // TODO: Style the form. ?>
            <form action="" method="POST">
                <input type="text" name="postTitle" placeholder="Enter title" /> <br />
                <textarea name="postContent" placeholder="Enter post content"></textarea> <br />
                <input type="submit" name="postSubmit" placeholder="Submit" />
            </form>
        </section>
    </main>
    
<?php require_once '../app/incl/footer.php'; ?>