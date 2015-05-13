<section class="container comments-section">
        <h3>Comments: </h3>
        <?php if($data['comments'] == null) : ?>
            <h5>No comments at the moment, which is sad, by the way...</h5>
        <?php endif; ?>
        <?php foreach ($data['comments'] as $comment): ?>
        <div class="comment">
            <h5 class="commentor-name"><?php echo $comment->author_firstname . ' ' . $comment->author_lastname; ?></h5>
            <div class="comment-content">
                <?php echo $comment->content ?>
            </div>
        </div>
        <?php endforeach; ?>

        <div class="add-comment-section">
            <h3>Add comment: </h3>
            <?php if(isset($_SESSION['username'])) : ?>
                <?php if($data['commentMsg'] != null) : ?>
                    <div class="msg">
                        <?php if($data['commentMsg']) echo $data['commentMsg']; ?>
                    </div>
                <?php endif; ?>
                <form action="" method="POST" class="add-comment-form">
                    <textarea name="commentContent" placeholder="Type in here something..."></textarea> <br />
                    <input type="submit" value="Submit comment" name="commentSubmit" />
                </form>
            <?php else : ?>
                <h5>You should be registered to leave comments, bro.</h5>    
            <?php endif; ?>
        </div>
    </section>