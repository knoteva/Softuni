<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Print Tag</title>
    <style>
    div {
        padding: 5px;;
    }
    </style>
</head>
<body>
<?php
if (isset($_POST["amount"], $_POST["interest"] )) {
    $amount = $_POST['amount'];
    $currency = $_POST['currency'];
    $interest = $_POST['interest'] / 12 / 100;
    $duration = $_POST['duration'];
    $result = round(($amount * pow ( (1 + $interest ) , $duration)), 2);

    switch ($currency) {
        case "USD":
            echo "$ ".$result;
            break;
        case "EUR":
            echo "€ ".$result;
            break;
        case "BGN":
            echo "$result лв.";
            break;
    }
}
?>

<form action="03CalculateInterest.php" method="post">
    <div>
        <label for="input">Enter Amount</label>
        <input type="text" name="amount" pattern="[0-9]+"/>
    </div>
    <div>
        <input type="radio" name="currency" value="USD" required />
        <label for="USD">USD</label>
        <input type="radio" name="currency"  value="EUR" />
        <label for="EUR">EUR</label>
        <input type="radio" name="currency" value="BGN" />
        <label for="BGN">BGN</label>
    </div>
    <div>
        <label for="interest">Compound Interest Amount</label>
        <input type="text" name="interest"/>
    </div>
    <div>
        <select name="duration">
            <option value="6 Months" selected="selected">6 Months</option>
            <option value="1 year">1 Year</option>
            <option value="2 Years">2 Years</option>
            <option value="5 Years">5 Years</option>
        </select>
        <input type="submit" value="Calculate"/>
    </div>
</form>

</body>
</html>