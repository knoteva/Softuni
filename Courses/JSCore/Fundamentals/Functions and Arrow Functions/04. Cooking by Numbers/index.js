function cook(input){
    let num = +input[0];
    for(let i = 1; i < input.length; i++){
        switch (input[i]) {
            case "chop":
                num /= 2;
                console.log(num);
                break;
            case "dice":
                num = Math.sqrt(num);
                console.log(num);
                break;
            case "spice":
                num += 1;
                console.log(num);
                break;
            case "bake":
                num *= 3;
                console.log(num);
                break;
            case "fillet":
                num -= num * 0.2;
                console.log(num);
                break;    
            default:
                break;
        }

    }
}

// cook(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']
// );