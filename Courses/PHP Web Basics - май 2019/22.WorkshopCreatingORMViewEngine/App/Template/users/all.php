<?php /** @var \App\Data\UserDTO[] $data */ ?>

<h2>All Users</h2>

<table border = "1">
    <thead>
    <tr>
        <td><b>Id</b></td>
        <td><b>Username</b></td>
        <td><b>FullName</b></td>
        <td><b>BornOn</b></td>
    </tr>
    </thead>

    <tbody>

        <?php foreach ($data as $userDTO): ?>
            <tr>
                <td><?= $userDTO->getId(); ?></td>
                <td><?= $userDTO->getUsername(); ?></td>
                <td><?= $userDTO->getFirstName(). " ". $userDTO->getLastName(); ?></td>
                <td><?= $userDTO->getBornOn(); ?></td>
            </tr>
        <?php endforeach; ?>
    </tbody>
</table>
<br/>
Go back to <a href="profile.php">Your profile</a>