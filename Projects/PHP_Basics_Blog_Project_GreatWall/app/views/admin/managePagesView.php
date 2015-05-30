<h5>Add new page</h5>
<?php if($data['msg'] != null) : ?>
	<div class="msg">
		<?php echo $data['msg']; ?>
	</div>
<?php endif; ?>
<form action="" method="POST">
	<form action="" method="POST">
        <input type="text" name="pageTitle" class="full-input" placeholder="Enter title" /> <br />
        <textarea name="pageContent" class="full-textarea" placeholder="Enter page content"></textarea> <br />
        <select name="pageStatus">
        	<option value="0">Private</option>
        	<option value="1">Public</option>
        </select>
        <input type="submit" name="pageSubmit" value="Submit page" />
    </form>

</form>

<h5>Manage pages: </h5>

<?php if(!empty($data['pages'])) : ?>
	<?php foreach($data['pages'] as $page) : ?>
		<div class="list-item row">
			<div class="eight columns">
				<h5 class="u-bold">
					<a href="<?php echo Config::get('paths', 'root'); ?>page/show/<?php echo $page->id; ?>">
						<?php echo $page->title; ?>
					</a>
				</h5>
			</div>
			<div class="four columns u-text-right item-options">
				<a href="">Edit</a> | 
				<a href="<?php echo Config::get('paths', 'root'); ?>admin/delete/page/<?php echo $page->id; ?>">Delete</a>
			</div>
		</div>
	<?php endforeach; ?>
<?php endif; ?>