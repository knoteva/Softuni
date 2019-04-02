function solve(input) {
  let map = new Map();
  for(let line of input){
      let all = line.split(' : ');
      let product = all[0];
      let price = +all[1];
      map.set(product, price);
  }
  let initials = new Set();
  Array.from(map.keys()).sort().forEach(k => initials.add(k[0]));
  let products =  Array.from(map.keys()).sort();
 
  for(let char of initials){
    console.log(char);
    for(let prod of products){
        if(prod.startsWith(char)){
            console.log(` ${prod}: ${map.get(prod)}`); 
        }
      }
  }

}
solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']

)
