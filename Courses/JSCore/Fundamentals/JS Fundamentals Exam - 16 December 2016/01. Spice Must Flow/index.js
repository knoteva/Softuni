function solve(input){
    input = +input;
    let count = 0;
    let result = -26;
    while(input >=100){
        result += input - 26;                           
        count++;
        input -=10;
    }
    if(count == 0){  
        result = 0;
    }
    console.log(count);
        console.log(result); 
}


solve(1);