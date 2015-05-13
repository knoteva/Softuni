<?php require_once '../app/incl/header-tiny.php'; ?>

    <main class="main container row">
        <section class="twelve columns">
            <article>
                <div><h2> <?php if (!empty ($data)) {echo $data[0]->title;} ?></h2></div>

                <div class="page-content">
                    <?php if (!empty ($data)) {echo $data[0]->content;} ?>
                </div>
            </article>
            </div>
        </section>
    </main>
    
<?php require_once '../app/incl/footer.php'; ?>