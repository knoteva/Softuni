function juice(input) {
    let heroData = [];
    for(let line of input){
        let tokens = line.split(' / ')
        let it1 = tokens[0];
        let it2 = Number(tokens[1]);
        let it3;
        if(tokens.length > 2){
            it3 = tokens[2].split(', ');
        } else {
            it3 = []
        }
        let hero = {
            name: it1,
            level: it2,
            items: it3
        }
        
        heroData.push(hero)
    }
    console.log(JSON.stringify(heroData))
    // for (let bottle in bottles) {
    //    console.log(bottle + ' => ' + bottles[bottle])
    //   }
}
juice(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
)