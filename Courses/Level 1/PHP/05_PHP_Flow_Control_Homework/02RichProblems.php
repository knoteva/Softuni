<!DOCTYPE html>
    <html>
    <head>
        <meta charset="UTF-8">
        <title>Rich People’s Problems</title>
        <style>
            form {
                padding-bottom: 20px;
            }

            table, tr, td, th {
                border: 1px solid black;
                padding: 5px;
                border-collapse: collapse;
            }

        </style>
    </head>
    <body>

    <form action="" method="post">
            <label for="tags">Enter Cars:</label>
            <input type="text" id="cars" name="cars" />
            <input type="submit" name="submit" />
        </form>

        <?php
        $colors = ["red", "blue", "yellow", "green"];
        //$quantity = array(1, 2, 3, 4, 5);
        if (isset($_POST['submit'])):?>
            <table>
                <thead>
                <tr>
                    <th>Car</th>
                    <th>Color</th>
                    <th>Count</th>
                </tr>
                </thead>
                <tbody>
                <?php
                $cars = explode(", ", htmlentities($_POST['cars']));
                foreach ($cars as $car):
                    //$color = array_rand($colors, 1);
                    $color = $colors[rand(0, count($colors) - 1)];
                    //$number = array_rand($quantity, 1);
                    $count = rand(1, 5);
                     ?>
                    <tr>
                        <td><?= $car; ?></td>
                        <td><?= $color; ?></td>
                        <td><?= $count; ?></td>
                    </tr>
                <?php endforeach; ?>
                </tbody>
            </table>
        <?php endif; ?>
    </body>
    </html>