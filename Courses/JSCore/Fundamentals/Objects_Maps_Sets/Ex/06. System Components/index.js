function solve(input) {
  let systems = new Map();

  //for(let line of input){
    for(let i = 0; i < input.length; i++){
    let [system, component, subComponent]=input[i].split(' | ')
      // let all = line.split(' | ');
      // let systemName = all[0];
      // let componentName = all[1];
      // let subcomponentName = all[2];
      //console.log(brand)
      if(!systems.get(system)){
        systems.set(system, new Map)
      }
      if(!systems.get(system).get(component)){
        systems.get(system).set(component, []);
      }
      systems.get(system).get(component).push(subComponent);
  }
  //console.log(systems)
  let sortedSystem = Array.from(systems.keys()).sort()
  .sort((a,b)=>systems.get(b).size - systems.get(a).size)
   for(let system of sortedSystem){
     console.log(system);
     let sortedComponents = Array.from(systems.get(system).keys())
        .sort((a,b)=>systems.get(system).get(b).length - systems.get(system).get(a).length)
     for(let component of sortedComponents){
         console.log(`|||${component}`);
        for(let sub of systems.get(system).get(component)){
          console.log(`||||||${sub}`)
        } 
     }
   }

}
// solve([
//   'SULS | Main Site | Home Page',
//   'SULS | Main Site | Login Page',
//   'SULS | Main Site | Register Page',
//   'SULS | Judge Site | Login Page',
//   'SULS | Judge Site | Submittion Page',
//   'Lambda | CoreA | A23',
//   'SULS | Digital Site | Login Page',
//   'Lambda | CoreB | B24',
//   'Lambda | CoreA | A24',
//   'Lambda | CoreA | A25',
//   'Lambda | CoreC | C4',
//   'Indice | Session | Default Storage',
//   'Indice | Session | Default Security'
// ])
