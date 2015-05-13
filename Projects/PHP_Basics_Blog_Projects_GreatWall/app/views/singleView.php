<?php require_once '../app/incl/header-tiny.php'; ?> 

    <main class="main container row">
        <section class="twelve columns">
            <article class="post">
                <h1 class="u-bold u-large-text">
                    <?php echo $data['post'][0]['title'] ?>
                </h1>
                
                <div class="post-meta u-upper u-bold">
                    Post added by <?php echo $data['post'][0]['author_username']; ?>
                    in <a href=""><?php echo $data['post'][0]['category']; ?></a> 
                    on <a href=""><?php echo $data['post'][0]['publish_date']; ?></a>
                </div>
                
                <div class="post-content">
                    <?php echo $data['post'][0]['content'] ?>
                </div>

                <div class="post-tags">
                    <span class="u-bold">Tags:</span> 
                    <?php  
                        $tagCount = count($data['tags']);
                        $counter = 1;
                    ?>
                    <em>
                        <?php if($tagCount < 1) echo 'no tags for this cool post, which is sad, by the way...'; ?>
                        <?php foreach($data['tags'] as $tag) : ?>
                            <a href="<?php echo Config::get('paths', 'root'); ?>search/tag/?name=<?php echo rawurlencode(rawurlencode($tag->tag_title)); ?>"><?php echo $tag->tag_title; ?></a>
                            <?php if($counter < $tagCount) echo ', '; ?>
                        <?php $counter++; endforeach; ?>
                    </em>
                </div>
            </article>
        </section>
    
    </main>

    <?php require_once '../app/incl/comments.php'; ?>
    
<?php require_once '../app/incl/footer.php'; ?>

