<h5>Add new category</h5>
<?php if($data['msg'] != null) : ?>
    <div class="msg">
        <?php echo $data['msg']; ?>
    </div>
<?php endif; ?>

<form action="" method="POST">
        <input name="categoryTitle" placeholder="Enter category"/input> <br />
        <input type="submit" name="categorySubmit" value="Submit category" />
</form>

<h5>Manage categories: </h5>

<?php if(!empty($data['categories'])) : ?>
    <?php foreach($data['categories'] as $category) : ?>
        <div class="list-item row">
            <div class="eight columns">
                <h5 class="u-bold">
                    <a href="<?php echo Config::get('paths', 'root'); ?>category/show/<?php echo $category->id; ?>">
                        <?php echo $category->title; ?>
                    </a>
                </h5>
            </div>
            <div class="four columns u-text-right item-options">
                <a href="">Edit</a> |
                <a href="<?php echo Config::get('paths', 'root'); ?>admin/delete/category/<?php echo $category->id; ?>">Delete</a>
            </div>
        </div>
    <?php endforeach; ?>
<?php endif; ?>