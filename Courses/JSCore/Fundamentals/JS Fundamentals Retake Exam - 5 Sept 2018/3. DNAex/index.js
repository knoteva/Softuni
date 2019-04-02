function solve(arr){

    let regex = /([a-z!@#$?]+)=([0-9]{1,})--([0-9]{1,})<<([a-z]+)/;
    let obj = {};
    for(let line of arr){
        if(line === "Stop!"){
            break;
        }
       //let matches = regex.exec(line);
        let matches = line.match(regex);
        if(matches){
            let name = matches[1].replace(/\W/g, '');
            //console.log(matches);
            if(name.length === +matches[2]){
                if(!obj.hasOwnProperty(matches[4])){
                    obj[matches[4]] = +matches[3];
                } else {
                    obj[matches[4]] += +matches[3];
                }
                
            }
            
        }
    }
    let sorted = [];
   for(let e in obj){
    sorted.push([e, obj[e]])
   }
   sorted.sort((a,b)=> b[1] - a[1])
//    for(animal of sorted){
//        console.log(`${animal[0]} has genome size of ${animal[1]}`)
//    }
   sorted.forEach((animal)=> console.log(`${animal[0]} has genome size of ${animal[1]}`))
   
}


// solve([ 
//     '!@ab?si?di!a@=7--152<<human',
//     'b!etu?la@=6--321<<dog',
//     '!curtob@acter##ium$=14--230<<dog',
//     '!some@thin@g##=9<<human',
//     'Stop!'
//     ]
// )
// solve([
//     '=12<<cat',
//     '!vi@rus?=2--142',
//     '?!cur##viba@cter!!=11--800<<cat',
//     '!fre?esia#=7--450<<mouse',
//     '@pa!rcuba@cteria$=13--351<<mouse',
//     '!richel#ia??=8--900<<human',
//     'Stop!'
//     ])
// solve([
//     '!@ру?би#=4--57<<polecat',
//     '?do?@#ri#=4--89<<polecat',
//     '=12<<cat',
//     '!vi@rus?=2--142',
//     '@pa!rcu>ba@cteria$=13--234<<mouse',
//     '?!cur##viba@cter!!=11--680<<cat',
//     'Stop!'

//     ])