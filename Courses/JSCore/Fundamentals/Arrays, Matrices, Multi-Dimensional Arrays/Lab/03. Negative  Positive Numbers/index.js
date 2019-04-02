function solve(input){
    let result =[]

    for(let i = 0; i < input.length; i++){     
        if(input[i] < 0) {
        result.unshift(input[i])
        }
        if(input[i] >= 0) {
       result.push(input[i])
        }
        
    }
    result.forEach(el => {
        console.log(el)
    });
    
}