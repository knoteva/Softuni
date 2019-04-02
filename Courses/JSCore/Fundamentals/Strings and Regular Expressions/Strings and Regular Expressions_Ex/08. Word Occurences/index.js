function solve(arr, arr1) {
    let pattern = new RegExp(`\\b${arr1}\\b`, 'gi');  
    if(arr.match(pattern)){
        console.log(arr.match(pattern).length)
    } else {
        console.log(0);
    }
    
}
 solve(' waterfall was so high, that  child couldn’t see its peak.',
'the');