function coffemachine(input) {
let order;
let coins = 0
let typeOfDring = "";
let typeOfCoffe = "";
let milk = false;
let sugar = 0;
let income = 0;

for(let i = 0; i < input.length; i++){
   order = input[i].split(', ');
   coins = +order[0];
   typeOfDring = order[1];
   if(order[1] === 'coffee'){
    typeOfCoffe = order[2];
   } else {
       typeOfCoffe = "";
   }
   if(order[3] === 'milk'){
    milk = order[3];
   } else if(order[2] === 'milk'){
       milk = order[2];
   } else {
       milk = '';
   }
   sugar = order[order.length - 1];
   let priceOfDrink = 0;
   if(typeOfCoffe === 'decaf'){
       priceOfDrink = 0.9;
   }
   else{
       priceOfDrink = 0.8
   }
   if(milk === 'milk'){
    priceOfDrink = Math.round((priceOfDrink*1.1) * 10) / 10;
   }
   if(sugar != 0){
    priceOfDrink += 0.1
   }
   
   if(priceOfDrink <= coins){
   
    income += priceOfDrink;
    let change = coins - priceOfDrink;
    console.log(`You ordered ${typeOfDring}. Price: ${priceOfDrink.toFixed(2)}$ Change: ${change.toFixed(2)}$`)  
   } else {
        let neddedMoney = priceOfDrink - coins;
        console.log(`Not enough money for ${typeOfDring}. Need ${neddedMoney.toFixed(2)}$ more.`)

   }


}   
console.log(`Income Report: ${income.toFixed(2)}$`)


}