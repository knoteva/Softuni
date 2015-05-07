<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Sidebar Builder</title>
    <style>
        aside {
            padding: 5px 0 5px 10px;
            border-radius: 5px;
            border: 1px solid black;
            margin: 5px;
            width: 200px;
        }
        h2 {
            border-bottom: 1px solid black;
        }
        a {
            color: black;
        }
        a:hover {
            color: red;
        }
        ul {
            list-style-type: circle;
        }
        form {
            margin: 10px;
        }
        label {
            margin: 5px;
        }
    </style>
</head>
<body>
<form action="" method="post">
    <label for="categories">Categories: <input type="text" name="categories" id="categories"></label>
    <label for="tags">Tags: <input type="text" name="tags" id="tags"></label>
    <label for="months">Months: <input type="text" name="months" id="months"></label>
    <input type="submit" name="submit" id="submit" value="Generate">
</form>

<?php if (isset($_POST['submit'])):
    $categories = explode(", ", $_POST['categories']);
    $tags = explode(", ", $_POST['tags']);
    $months = explode(", ", $_POST['months']); ?>

    <aside>
        <h2>Categories</h2>
        <ul>
            <?php foreach ($categories as $categoryEntry): ?>
                <li><a href=#><?php echo htmlentities($categoryEntry); ?></a></li>
            <?php endforeach; ?>
        </ul>
    </aside>

    <aside>
        <h2>Tags</h2>
        <ul>
            <?php foreach ($tags as $tagEntry): ?>
                <li><a href=#><?php echo htmlentities($tagEntry); ?></a></li>
            <?php endforeach; ?>
        </ul>
    </aside>

    <aside>
        <h2>Months</h2>
        <ul>
            <?php foreach ($months as $monthEntry): ?>
                <li><a href=#><?php echo htmlentities($monthEntry); ?></a></li>
            <?php endforeach; ?>
        </ul>
    </aside>

<?php endif; ?>

</body>
</html>