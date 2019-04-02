function solve(lostFightsCount, helmetPrice, swordPrice, shieldtPrice, armorPrice){
    let neededMoney = 0;
    let helmetCount = 0;
    let swordCount = 0;
    let shieldCount = 0;
    let armorCount = 0;
    for(let i = 1; i <= lostFightsCount; i++ ){
        if(i % 2 === 0){
            neededMoney += +helmetPrice;
            helmetCount++;
        }
        if(i % 3 === 0){
            neededMoney += +swordPrice;
            swordCount++;
        }
        if(i % 2 === 0 && i % 3 === 0){
            neededMoney += +shieldtPrice;
            shieldCount++;
        }
        if(shieldCount % 2 === 0 && shieldCount > 0){
            neededMoney += +armorPrice;
            armorCount++;
            shieldCount = 0;
        }
    }
    console.log(`Gladiator expenses: ${neededMoney.toFixed(2)} aureus`);
    //  console.log(helmetCount);
    //  console.log(swordCount);
    //  console.log(shieldCount);
    //  console.log(armorCount);
}

 //solve([23], [12.50], [21.50], [40], [200]);