<li><a href="<?php echo Config::get('paths', 'root') ?>">Home</a></li>
<?php if (!empty($nav)) : ?>
    <?php foreach ($nav as $n) : ?>
        <li><a href="<?php echo Config::get('paths', 'root') ?>page/show/<?php echo $n->id; ?>"><?php echo $n->title; ?></a></li>
    <?php endforeach; ?>
<?php endif; ?>
<?php if (!isset($_SESSION['username'])) : ?>
    <li><a href="<?php echo Config::get('paths', 'root') ?>user/login">Login</a></li>
    <li><a href="<?php echo Config::get('paths', 'root') ?>user/register">Register</a></li>
<?php else : ?>
    <li><a href="<?php echo Config::get('paths', 'root') ?>user/me">Profile</a></li>
    <?php if($_SESSION['role'] == 'admin') : ?>
    	<li><a href="<?php echo Config::get('paths', 'root') ?>admin">Admin panel</a></li>
	<?php endif; ?>
    <li><a href="<?php echo Config::get('paths', 'root') ?>user/logout">Logout (<?php echo $_SESSION['username']; ?>)</a></li>
<?php endif; ?>