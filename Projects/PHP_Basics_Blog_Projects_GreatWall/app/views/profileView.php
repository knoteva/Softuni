<?php require_once '../app/incl/header-tiny.php'; ?>
    <main class="main container row">
        <section class="twelve columns">
            <article>
                <div><h2 class="profile-name u-large-text u-text-center"><?php echo $_SESSION['firstname'] . ' ' . $_SESSION['lastname']; ?></h2></div>
                <h4 class="profile-msg u-text-center">
                    <?php if($_SESSION['role'] == 'admin') : ?>
                        Hello, <?php echo $_SESSION['firstname']; ?>. I don't know if you're aware, but you appear to be the admin of this blog. <a href="<?php echo Config::get('paths', 'root') ?>admin">So, go and rule</a>!
                    <?php else : ?>
                        Hello, <?php echo $_SESSION['firstname']; ?>. You're currently in your profile. Here you can track your activity and tweak your personal information!
                    <?php endif; ?>
                </h4>
                
                
                <div class="page-content row">
                    <div class="eight columns">
                        <h5 class="u-bold">Latest 5 comments: </h5>
                        <?php if($data['myComments']) : ?>
                            <?php $commentsCount = 1; ?>
                            <?php foreach($data['myComments'] as $comment) : ?>
                                <?php if($commentsCount <= 5) : ?>
                                    <h5>
                                        On: 
                                        <a class="u-bold" href="<?php echo Config::get('paths', 'root'); ?>post/show/<?php echo $comment->post_id; ?>">
                                            <?php echo $comment->post_title; ?>
                                        </a>
                                    </h5>
                                    <div style="margin-left: 20px;">
                                        <p><?php echo $comment->content; $commentsCount++; ?></p>
                                    </div>
                                <?php endif; ?>
                            <?php endforeach; ?>
                        <?php endif; ?>
                    </div>
                    
                    <div class="four columns">
                        <h5 class="u-bold">Current information: </h5>
                        Username: <?php echo $_SESSION['username']; ?> <br />
                        Email: <?php echo $_SESSION['email']; ?><br />
                        Role: <?php echo $_SESSION['role']; ?> <br /><br />
                        
                        <h5>Options: </h5>
                        <ul class="non-bullet">
                            <li><a href="">Change username</a></li>
                            <li><a href="">Change password</a></li>
                        </ul>
                    </div>
                </div>
                
            </article>
            </div>
        </section>
    </main>
    
<?php require_once '../app/incl/footer.php'; ?>