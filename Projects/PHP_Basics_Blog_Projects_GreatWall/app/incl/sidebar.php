        <aside class="four columns sidebar">
            <div class="sidebar-item">
                <h5>Latest posts</h5>
                <ul class="non-bullet">
                    <?php $counter = 1; ?>
                    <?php foreach($data['posts'] as $post) : ?>
                        <?php if($counter <= 5) : ?>
                            <li>
                                <a href="<?php echo Config::get('paths', 'root') ?>post/show/<?php echo $post['id']; ?>">
                                    <?php echo $post['title']; $counter++; ?>
                                </a>
                            </li>
                        <?php endif; ?>
                    <?php endforeach; ?>
                </ul>
            </div>
            
            <div class="sidebar-item">
                <h5>Categories</h5>

                <ul class="non-bullet">
                    <?php $catCounter = 1; ?>
                    <?php foreach($data['categories'] as $cat) : ?>
                        <?php if($catCounter <= 7) : ?>

                            <li>
                                <a href="<?php Config::get('paths', 'root'); ?>search/category/?name=<?php echo rawurlencode(rawurlencode($cat->title)); ?>">
                                    <?php echo $cat->title ?><?php $catCounter++;?>
                                </a>
                            </li>
                        <?php endif; ?>
                    <?php endforeach; ?>
                </ul>
            </div>
            
            <div class="sidebar-item">
                <h5>Most popular tags</h5>
                
                <ul class="non-bullet">
                    <?php $tagCounter = 1; ?>
                    <?php foreach($data['tags'] as $tag) : ?>
                        <?php if($tagCounter <= 7) : ?>
                            <li>
                                <a href="<?php Config::get('paths', 'root'); ?>search/tag/?name=<?php echo rawurlencode($tag->title); ?>">
                                    <?php echo $tag->title ?>(<?php echo $tag->tag_magnitude; $tagCounter++;?>)
                                </a>
                            </li>
                        <?php endif; ?>
                    <?php endforeach; ?>
                </ul>
            </div>
        </aside>