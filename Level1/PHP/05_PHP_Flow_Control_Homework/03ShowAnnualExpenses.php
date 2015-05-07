<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Show Annual Expenses</title>
    <style>
        table {
            border: 1px solid black;
        }
        tr, th, td{
            border: 1px solid black;
            padding: 5px;
        }
        td {
            text-align: right;
        }
    </style>
</head>
<body>
<form action="" method="post">
    <label for="tags">Enter number of years:</label>
    <input type="text" id="years" name="years" />
    <input type="submit" name="submit" value="Show costs" />
</form>
<?php
date_default_timezone_set("Europe/Sofia");

if (isset($_POST['submit'])):
    $count = $_POST['years'];
    $year = date('Y'); ?>
<!--$months = array("January", "February", "March", "April", "May", "June", "July", "August",-->
<!--"September", "October", "November", "December");-->
<!--echo "<table>";-->
<!--    echo "<thead><td>Year</td>";-->
<!--    foreach ($months as $month){-->
<!--    echo "<td>$month</td>";-->
<!--    }-->
<table>
    <thead>
    <tr>
        <th>Year</th>
        <th>January</th>
        <th>February</th>
        <th>March</th>
        <th>April</th>
        <th>May</th>
        <th>June</th>
        <th>July</th>
        <th>August</th>
        <th>September</th>
        <th>October</th>
        <th>November</th>
        <th>December</th>
        <th>Total:</th>
    </tr>
    </thead>

    <tbody>

    <?php for ($i = $year; $i >= $year - $count + 1; $i--): ?>
        <tr>
            <td><?php echo $i ?></td>

            <?php $total = 0;
            for ($m = 0; $m < 12; $m++):
                $expenses = rand(0, 999);
                $total += $expenses; ?>
                <td><?php echo $expenses ?></td>
            <?php endfor; ?>
            <td><?php echo $total ?></td>
        </tr>
    <?php endfor; ?>
    </tbody>
</table>
<?php  endif; ?>
</body>
</html>