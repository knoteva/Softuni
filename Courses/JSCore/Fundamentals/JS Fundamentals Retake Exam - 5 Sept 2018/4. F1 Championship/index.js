function solve(arr){
    let map = new Map();
    for(let line of arr){
        let [team, pilot, points] = line.split(' -> ');
        if(!map.has(team)){
            map.set(team, new Map());
        }
        if(!map.get(team).has(pilot)){
            map.get(team).set(pilot, +points);
        } else {
            map.get(team).set(pilot, map.get(team).get(pilot) + Number(points));
        }
        //map.get(team).get(pilot).set(map.get(team).get(pilot) + Number(points))
    }
    let sortedMap = [...map].sort((a,b)=> +[...b[1].values()]
                        .reduce((a,b)=> a+b) -+[...a[1].values()]
                        .reduce((a,b)=> a+b))
                        .slice(0,3);
    
    for([team, pilot] of sortedMap){
        console.log(`${team}: ${[...pilot.values()].reduce((a,b)=>a+b)}`)
    let sortedPilots = [...pilot].sort((a,b) => b[1] - a[1])
        for([pil, points] of sortedPilots){
            console.log(`-- ${pil} -> ${points}`)
        }
    }
}


solve([
    "Ferrari -> Kimi Raikonnen -> 25",
    "Ferrari -> Sebastian Vettel -> 18",
    "Mercedes -> Lewis Hamilton -> 10",
    "Mercedes -> Valteri Bottas -> 8",
    "Red Bull -> Max Verstapen -> 6",
    "Red Bull -> Daniel Ricciardo -> 4"
])