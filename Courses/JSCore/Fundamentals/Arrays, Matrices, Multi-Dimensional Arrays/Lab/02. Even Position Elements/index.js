function solve(input){
    let result = ''
    for(let i = 0; i < input.length; i+=2){
        
        result +=" " + input[i]

    }
    console.log(result)
}

solve(['20', '30', '40']);

// function solve(arr) {
//     return arr
//       .filter((num, i) => i % 2 == 0)
//       .join(' ');
// }