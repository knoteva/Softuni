function solve(arr){
    let sum = arr.filter((e, i) => i==0 || i==arr.length-1)
               .reduce((a,b) => +a + +b,)
    if(arr.length > 1){
        console.log(sum);
    } else {
        console.log(sum * 2);
    }
    
    //return Number(arr[0]) + Number(arr[arr.length - 1]);

   // console.log(arr.splice(1, arr.length - 2))
}

solve(['5']);