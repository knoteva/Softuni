<?php
$users_login = [];
$failed_login = 0;
while (true){
    $input = readline();
    if ($input === 'login'){
        while (true){
            $input = readline();
            if ($input === 'end'){
                echo 'unsuccessful login attempts: '.$failed_login;
                return;
            }
            $tokens = explode(' -> ', $input);
            $user_name = $tokens[0];
            $password = $tokens[1];
            if (array_key_exists($user_name, $users_login)){
                if ($users_login[$user_name] === $password){
                    echo $user_name.': logged in successfully'.PHP_EOL;
                }else{
                    echo $user_name.': login failed'.PHP_EOL;
                    $failed_login++;
                }
            }else{
                echo $user_name.': login failed'.PHP_EOL;
                $failed_login++;
            }
        }
    }
    $tokens = explode(' -> ', $input);
    $user_name = $tokens[0];
    $password = $tokens[1];
    //if (!array_key_exists($user_name, $users_login)){
      //  $users_login[$user_name] = '';
   // }
    $users_login[$user_name] = $password;
}