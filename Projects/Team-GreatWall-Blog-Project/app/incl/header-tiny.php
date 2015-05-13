<!DOCTYPE html>
<html>
    <meta charset="utf-8" />
    <title>This is the blog.</title>
    
    <!-- HARDCODE THE STYLE URL: -->
    <link rel="stylesheet" href="http://localhost<?php echo Config::get('paths', 'root'); ?>/css/style.css" type="text/css" />
    <script src="http://tinymce.cachefly.net/4.1/tinymce.min.js"></script>
    <?php // TODO: fix font-size of tiny-mce ?>
    <script>
        tinymce.init({
            selector:'textarea',
        });
    </script>
<body>
    <header class="header u-text-center">
        <div class="container">
            <nav class="top-nav nav">
                <ul class="u-upper u-bold">
                    <?php include Config::get('paths', 'incl') . 'navigation.php'; ?>
                </ul>
            </nav>
        </div>
    </header>