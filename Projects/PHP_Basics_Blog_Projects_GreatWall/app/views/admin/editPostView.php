<?php require_once Config::get('paths', 'views') . 'admin/addpostView.php';?>

<h5>Add new post: </h5>

<?php if($data['msg'] != null) : ?>
    <div class="msg">
        <?php echo $data['msg']; ?>
    </div>
<?php endif; ?>

<form action="" method="POST">
    <input type="text" name="postTitle" class="full-input" placeholder="Enter title" /> <br />

    <textarea name="postContent" class="full-textarea" placeholder="Enter post content"></textarea> <br />

    <label for="postTags">Insert tags: </label>
    <input class="full-input" type="text" name="postTags" placeholder="Separate those bitches by comma: " />

    <select name="postCategory">
        <?php if(isset($data['categories'])):?>
            <?php foreach($data['categories'] as $d):?>

                <option value="<?php echo $d->id;?>"><?php echo $d->title?></option>

            <?php endforeach; ?>
        <?php endif; ?>
    </select>

    <select name="postVisibility">
        <option value="1">Public</option>
        <option value="0">Private</option>
    </select>
    <br />

    <input type="submit" name="postSubmit" value="Submit post" />
</form>