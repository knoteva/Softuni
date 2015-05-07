<!DOCTYPE html>
    <html>
        <head>
            <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
            <title>Information Table</title>
            <style>
                table {
                    border-collapse: collapse;
                }
                tr, th, td{
                    border: 1px solid black;
                    padding: 5px;
                }
                th {
                    background-color: orange;
                    text-align: left;
                }
                td {
                    text-align: right;
                }
            </style>
        </head>

        <body>
            <?php
                function table($name, $phone, $age, $address) {
                    echo "<table>";
                    echo "<tr><th>Name</th><td>$name</td></tr>";
                    echo "<tr><th>Phone Number</th><td>$phone</td></tr>";
                    echo "<tr><th>Age</th><td>$age</td></tr>";
                    echo "<tr><th>Address</th><td>$address</td></tr>";
                    echo "</table><br>";
                }
            table("Gosho", "0882-321-423", "24", "Hadji Dimitar");
            table("Pesho", "0884-888-888", "67", "Suhata Reka");

            ?>
        </body>
    </html>
