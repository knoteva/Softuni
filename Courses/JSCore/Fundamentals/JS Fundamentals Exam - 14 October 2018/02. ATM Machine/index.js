function ATM(input) {
    let command;
    let insertedMoney = 0;
    let totalCashATM = 0;
    let accountBalance = 0;
    let withdraw = 0;
    let banknoteWithdraw = 0;
    let d1 = 0;
    let d2 = 0;
    let d5 = 0;
    let d10 = 0;
    let d20 = 0;
    let d50 = 0;
    let d100 = 0;
    let banknoteType = "";
    let banknoteCount = 0;
    for(let i = 0; i < input.length; i++){
        command = input[i];
        //console.log(input[i].length);
        if(command.length > 2) {
            command.forEach(banknote => {
                if(banknote == 1){d1++;}
                if(banknote == 2){d2++;}
                if(banknote == 5){d5++;}
                if(banknote == 10){d10++;}
                if(banknote == 20){d20++;}
                if(banknote == 50){d50++;}
                if(banknote == 100){d100++;}
            });
            insertedMoney += +command.reduce((a, b) => a + b, 0);
            totalCashATM += +command.reduce((a, b) => a + b, 0);
            console.log(`Service Report: ${insertedMoney}$ inserted. Current balance: ${totalCashATM}$.`)
            insertedMoney = 0;    
        }
        if(command.length == 2) {
            accountBalance = command[0];
            withdraw = command[1];
            if(accountBalance < withdraw){
                console.log(`Not enough money in your account. Account balance: ${accountBalance}$.`);
            } else if(withdraw > totalCashATM){
                console.log(`ATM machine is out of order!`);
            } else {             
                banknoteWithdraw = withdraw;
                while(banknoteWithdraw > 0){
                    //if(d100 >= banknoteWithdraw/100)
                    if(d100>= 0){d100 -= Math.floor(banknoteWithdraw/100);banknoteWithdraw %= 100;}
                    //if(d50 >= banknoteWithdraw/50)
                    if(d50>= 0){d50 -= Math.floor(banknoteWithdraw/50);banknoteWithdraw %= 50;}
                    //if(d20 >= banknoteWithdraw/20)
                    if(d20>= 0){d20 -= Math.floor(banknoteWithdraw/20);banknoteWithdraw %= 20;}
                    //if(d10 >= banknoteWithdraw/10)
                    if(d10>= 0){d10 -= Math.floor(banknoteWithdraw/10);banknoteWithdraw %= 10;}
                    //if(d5 >= banknoteWithdraw/5)
                    if(d5>= 0){d5 -= Math.floor(banknoteWithdraw/5);banknoteWithdraw %= 5;}
                    //if(d2 >= banknoteWithdraw/2)
                    if(d2>= 0){d2 -= Math.floor(banknoteWithdraw/2); banknoteWithdraw %= 2;}
                    //if(d1 >= banknoteWithdraw/1)
                    if(d1>= 0){d1 -= Math.floor(banknoteWithdraw/1);banknoteWithdraw %= 1;}       
                }    
                accountBalance -= withdraw;
                totalCashATM -= withdraw;
                console.log(`You get ${withdraw}$. Account balance: ${accountBalance}$. Thank you!`);
            }           
        }
        if(command.length == 1) {
            command.forEach(banknote => {
                if(banknote == 1){banknoteType = 1;banknoteCount = d1;}
                if(banknote == 2){banknoteType = 2;banknoteCount = d2;}
                if(banknote == 5){banknoteType = 5;banknoteCount = d5;}
                if(banknote == 10){banknoteType = 10;banknoteCount = d10;}
                if(banknote == 20){banknoteType = 20;banknoteCount = d20;}
                if(banknote == 50){banknoteType = 50;banknoteCount = d50;}
                if(banknote == 100){banknoteType = 100;banknoteCount = d100;}
            });
            console.log(`Service Report: Banknotes from ${banknoteType}$: ${banknoteCount}.`)
        }
        
    }
  
}
    ATM([
        [10],
[20, 20, 50],
[20],
[100, 50],
[100, 100, 500, 10, 10, 20],
[50, 100],
[500, 500]
       ])