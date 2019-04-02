function solve(input) {
    let quants = {};
    let bottles = {};
    for(let line of input){
        let tokens = line.split(' => ')
        let fruit = tokens[0]
        let quant = +tokens[1]
        if(!quants.hasOwnProperty(fruit)){
            quants[fruit] = 0
        }
        quants[fruit] +=quant
        if(quants[fruit] >= 1000){
            bottles[fruit] = parseInt(quants[fruit]/1000)
        }    
    }
    for (let bottle in bottles) {
       console.log(bottle + ' => ' + bottles[bottle])
      }
}
solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']
)
