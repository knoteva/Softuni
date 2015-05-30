<?php require_once '../app/incl/header-tiny.php'; ?>

    <main class="main container row">
        <section class="twelve columns">
            <article>
                <div><h2> Results on: <span class="u-bold"><?php echo $data['searchTerm']; ?></span></h2></div>

                <div class="page-content">
                    <?php if(!empty($data['results'][0])) : ?>
                        <?php foreach($data['results'] as $post) : ?>
                            <h4 class="u-bold">
                                <a href="<?php echo Config::get('paths', 'root'); ?>post/show/<?php echo $post->id; ?>">
                                    <?php echo $post->title; ?> &rarr;
                                </a>
                            </h4>
                        <?php endforeach; ?>
                    <?php else : ?>
                        <h5>Oh, boy, no luck today. Go kill yourself. :)</h5>
                    <?php endif; ?>
                </div>
            </article>
            </div>
        </section>
    </main>
    
<?php require_once '../app/incl/footer.php'; ?>