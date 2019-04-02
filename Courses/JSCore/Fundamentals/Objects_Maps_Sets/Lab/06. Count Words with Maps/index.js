//for Judge:
//function solve([arr]){
function solve(arr){
  
    let regex = /\w+/g;
    let result = new Map();
    let matches = arr.toLowerCase().match(regex);
    matches.forEach(match => {
        if(!result.has(match)) {
            result.set(match, 1);
        } else {
            result.set(match, result.get(match) + 1);
        }
    });  
    let sorted = Array.from(result.keys()).sort();
    for(let key of sorted) {
        console.log("'" + key + "'" + " -> " + result.get(key) + " times");
    }
    //console.log(JSON.stringify(result));
}

solve('Far too slow, you\'re far too slow.')

