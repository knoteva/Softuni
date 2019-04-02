<!DOCTYPE html>
    <html>
    <head>
        <title>Square Root Sum</title>
        <style>
            table {
                margin: 0 auto;
            }
            table, tr, td, th {
                border: 1px solid black;
                padding: 5px;
                border-collapse: collapse;
            }
            tr > th, tfoot > tr > td{
                font-weight: bold;
            }
        </style>
    </head>
    <body>
        <table>
            <thead>
            <tr>
                <th>Number</th>
                <th>Square</th>
            </tr>
            </thead>
            <tbody>
            <?php
            $sum = 0;
            ?>
            <?php for ($i = 0; $i < 101; $i += 2):?>
                <?php $sum += round(sqrt($i), 2); ?>
                <tr>
                    <td> <?= $i;?> </td>
                    <td> <?= round(sqrt($i), 2); ?> </td>
                </tr>

            <?php endfor; ?>

            </tbody>
            <tfoot>
            <tr>
                <td>Total</td>
                <td> <?= round($sum, 2); ?> </td>
            </tr>
            </tfoot>
        </table>
    </body>
    </html>
