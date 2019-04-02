function solve(input) {
  let names = new Set();
  for(let name of input){
    names.add(name);
  }
  let sortedNames = Array.from(names).sort((a,b)=> a.length - b.length ||  a.localeCompare(b));
  for(let name of sortedNames){
    console.log(name);
  }
  
}
// solve([
// 'Denise',
// 'Ignatius',
// 'Iris',
// 'Isacc',
// 'Indie',
// 'Dean',
// 'Donatello',
// 'Enfuego',
// 'Benjamin',
// 'Biser',
// 'Bounty',
// 'Renard',
// 'Rot'
// ])
