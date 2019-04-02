function solve(str) {
    let products = [];
    let amount = 0;
    for(let i = 0; i < str.length; i+=2){
        let product = str[i];
        amount += +str[i + 1];
        products.push(product);
    }
    //product = product.trim().slice(0, -1);
    console.log(`You purchased ${products.join(', ')} for a total sum of ${amount}`);
    //console.log(typeof product);
    
}

//solve(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);
