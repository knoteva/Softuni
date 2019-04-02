//for Judge:
//function solve([arr]){
function solve(arr){
  
    let regex = /\w+/g;
    let result = {};
    let matches = arr.match(regex);
    matches.forEach(match => {
        if(!result.hasOwnProperty(match)) {
            result[match] = 1;
        } else {
            result[match]++;
        }
    });  
    //console.log(result);
    console.log(JSON.stringify(result));
}

solve('Far too slow, you\'re far too slow.')

