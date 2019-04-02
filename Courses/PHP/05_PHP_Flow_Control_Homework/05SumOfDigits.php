<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Sum of digits</title>
    <style>
        table {
            border: 1px solid black;
        }
        tr, th, td{
            border: 1px solid black;
            padding: 5px;
        }
        td {
            text-align: left;
        }
    </style>
</head>
<body>
<form action="" method="post">
    <label for="tags">Input String:</label>
    <input type="text" id="nums" name="nums" />
    <input type="submit" name="submit" />
</form>
<?php

if (isset($_POST['submit'])):
$nums = explode(", ", $_POST['nums']); ?>
<table>
    <?php
    foreach ($nums as $num):
        $sumOfDigits = 0; ?>
    <tr>
        <td><?php echo $num ?></td>
        <td>
            <?php if (is_numeric($num)):
                while ($num > 0) {
                    $sumOfDigits += $num % 10;
                    $num /= 10;
                }
                echo $sumOfDigits;
            else:
                echo "I cannot sum that";
            endif; ?>
        </td>
    </tr>
    <?php endforeach; ?>
</table>

<?php  endif; ?>
</body>
</html>
