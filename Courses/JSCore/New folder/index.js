function market(input) {

    let whiskyPrice = Number(input[0])
    
    let beerQuantity = Number(input[1])
    
    let wineQuantity = Number(input[2])
    
    let rakyaQuantity = Number(input[3])
    
    let whiskyQuantity = Number(input[4])
    
     
    
    let rakyaPrice = whiskyPrice * 0.5;
    
    let winePrace = rakyaPrice - (rakyaPrice * 0.4)
    
    let beerPrace = rakyaPrice - (rakyaPrice * 0.8)
    
    let rakyaSum = rakyaPrice * rakyaQuantity;
    
    let wineSum = winePrace * wineQuantity;
    
    let beerSum = beerPrace * beerQuantity;
    
    let whiskySum = winePrace  * whiskyQuantity;
    
    let totalSum = whiskySum + wineSum + beerSum + rakyaSum;

    console.log(totalSum.toFixed(2))
    }
    market([50,
        10,
        3.5,
        6.5,
        1,
        ]);