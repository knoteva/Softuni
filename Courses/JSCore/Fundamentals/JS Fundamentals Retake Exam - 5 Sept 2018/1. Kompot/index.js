function solve(arr){
    let peachKompots = 0;
    let plumKompots = 0;
    let cherryKompots= 0;
    let rakiaKompots = 0    
 for(let line of arr){  
    let [fruitType, fruitKol] = line.split(/\s+/);

    if(fruitType === "peach"){
        peachKompots += +fruitKol*1000/140/2.5

    } else if(fruitType === "plum"){
        plumKompots += +fruitKol*1000/20/10

    } else if(fruitType === "cherry"){
        cherryKompots += +fruitKol*1000/9/25

    } else {
        rakiaKompots += +fruitKol*0.200

    }
    
 }
 console.log("Cherry kompots: " + Math.floor(cherryKompots) + '\n' + "Peach kompots: " + 
 Math.floor(peachKompots) + "\n" + "Plum kompots: " +  Math.floor(plumKompots) + "\n" + "Rakiya liters: " +
 rakiaKompots.toFixed(2))

}


solve([ 
    'cherry 1.2',
    'peach 2.2', 
    'plum 5.2',
    'peach 0.1', 
    'cherry 0.2', 
    'cherry 5.0', 
    'plum 10',
    'cherry 20.0',
    'papaya 20' 
])