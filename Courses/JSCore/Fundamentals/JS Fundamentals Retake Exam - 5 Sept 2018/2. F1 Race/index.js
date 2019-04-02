function solve(arr){

    let move = function(array, element, delta) {
        let index = array.indexOf(element);
        let newIndex = index + delta;
        if (newIndex < 0  || newIndex == array.length) return; //Already at the top or bottom.
        let indexes = [index, newIndex].sort(); //Sort the indixes
        array.splice(indexes[0], 2, array[indexes[1]], array[indexes[0]]); //Replace from lowest index, two elements, reverting the order
      };
      
      let moveUp = function(array, element) {
        move(array, element, -1);
      };
      
      let moveDown = function(array, element) {
        move(array, element, 1);
      };
    
let pilots = arr.shift().split(' ');
for(let line of arr){
    let command = line.split(' ')[0];
    let pil = line.split(' ')[1];
    switch(command){
        case "Join":
            if(!pilots.includes(pil)){
                pilots.push(pil);
            }
            break;
        case "Crash":
        if(pilots.includes(pil)){
            pilots = pilots.filter(function(e) { return e !== pil })
        }
            break;
        case "Pit":
        if(pilots.includes(pil)){
            moveDown(pilots, pil);
        }
            break;
        case "Overtake":
            if(pilots.includes(pil)){
                moveUp(pilots, pil);
            }
            break;        
        default:
            break;    
    }
    //console.log(pil);
}

console.log(pilots.join(' ~ '));
}


// solve([
//     "Hamilton AAA b v",
//     "Join b",
//     "Join v",
//     "Join Hamilton",
//     "Join AAA",
//     "Overtake b"

// ])