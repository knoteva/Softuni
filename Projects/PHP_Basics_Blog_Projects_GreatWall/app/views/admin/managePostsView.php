<?php require_once '../app/incl/header-tiny.php'; ?>
<h5>Manage posts: </h5>

<?php if(!empty($data['posts'])) : ?>
    <?php foreach($data['posts'] as $page) : ?>
        <div class="list-item row">
            <div class="eight columns">
                <h5 class="u-bold">
                    <a href="<?php echo Config::get('paths', 'root'); ?>post/show/<?php echo $page['id']; ?>">
                        <?php echo $page['title']; ?>
                    </a>
                </h5>
            </div>
            <div class="four columns u-text-right item-options">
                <a href="<?php echo Config::get('paths', 'root'); ?>admin/edit/post/<?php echo $page['id']; ?>">Edit</a> |
                <a href="<?php echo Config::get('paths', 'root'); ?>admin/delete/post/<?php echo $page['id']; ?>">Delete</a>
            </div>
        </div>
    <?php endforeach; ?>
<?php endif; ?>
<?php require_once '../app/incl/footer.php'; ?>