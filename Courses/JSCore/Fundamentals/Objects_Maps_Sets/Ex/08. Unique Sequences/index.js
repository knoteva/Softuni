function solve(input) {
  let arraysSet = [];
  let sets = new Set()
  for(let line of input) {
      let arr = JSON.parse(line);
      arraysSet.push(arr.sort((a, b) => b - a));
  }
  let firsArr = JSON.stringify(arraysSet);
  for(let i = 1; i < arraysSet.length; i++){
    if(firsArr != JSON.stringify(arraysSet[i])){
      sets.add(arraysSet[i]);
    } else {
      sets.delete(arraysSet[i])
    }
      
  }

  console.log(sets)
  
}
solve([
  "[-3, -2, -1, 0, 1, 2, 3, 4]",
  "[4, -3, 3, -2, 2, -1, 1, 0]", 
  "[10, 1, -17, 0, 2, 13]" 
])
