function solve(input){
    let map = new Map();
    let product = "";
    let price = 0;
    let town = "";
    for(let line of input) {
        tokens = line.split(' | ');
        product = tokens[1];
        price = +tokens[2];
        let town = tokens[0];
        if(!map.has(product)) {
            map.set(product, new Map());
        }
        map.get(product).set(town, price);
    }
    // for(let [product, insideMap] of map) {
    //     for(let [town, price] of insideMap) {
    //         console.log(`${product} -> ${price} (${town})`);
    //     }
    // }
    for(let [product, insideMap] of map) {
        let lowestPrice = Number.POSITIVE_INFINITY;
        let townWithLowestPrice = "";
        for(let [town, price] of insideMap) {
            if(price < lowestPrice) {
                lowestPrice = price;
                townWithLowestPrice = town;
            }
        }

        //console.log(`${product} -> ${lowestPrice} (${townWithLowestPrice})`);
    }
}

solve([
    'Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999'
]
)