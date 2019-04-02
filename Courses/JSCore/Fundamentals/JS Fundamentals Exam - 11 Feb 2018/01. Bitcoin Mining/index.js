function solve(arr){
    let day = 0;
    let oneBitcoin = 11949.16;
    let oneGofGold	= 67.51;
    let gold = 0;
    let firstDay = true;
   for(let i = 0; i < arr.length; i++){
       if((i + 1) % 3 == 0){
        arr[i] -= arr[i] * 0.3;
       }
        gold += +arr[i] * oneGofGold;
        if(firstDay){
            day++;
        }
        
        if(gold >= oneBitcoin){

            firstDay = false;
        }
        
        //console.log(arr[i]);
    }   
    let bitcoins = Math.floor(gold/oneBitcoin);
    console.log(`Bought bitcoins: ${bitcoins}`);
    if(bitcoins > 0){
        console.log(`Day of the first purchased bitcoin: ${day}`);
    }
   
    console.log(`Left money: ${(gold % oneBitcoin).toFixed(2)} lv.`);
}
solve(['100','200', '300']);
//solve(['3124.15', '504.212', '2511.124'])