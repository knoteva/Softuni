function solve(input){
    let inventory = input.shift().split(' ');
    let command = "";
    let equipment = "";
    let result = []
    for(let el of inventory){
        result.push(el);
    }   
    //console.log(result);
    //while(command !== "Fight!"){
        for(let line of input){
            command = line.split(' ')[0];
            equipment = line.split(' ')[1];
            
            switch(command){
                case "Buy":
                    if(!result.includes(equipment)){
                        result.push(equipment);
                    }
                    break;
                case "Trash":
                if(result.includes(equipment)){
                    result = result.filter(item => item !== equipment);
                }
                    break;
                case "Repair":
                if(result.includes(equipment)){
                    //result.splice(index, 1).push(equipment);
                    result.push(result.splice(result.indexOf(equipment), 1)[0]);
                }
                    break;
                case "Upgrade":
                    let up  = equipment.split('-')[0];
                    //console.log();
                    if(result.includes(up)){
                        //console.log(equipment);
                        equipment = equipment.replace("-", ":");
                        result.splice(result.indexOf(up) + 1, 0, equipment);
                    }
                    break;
                default:
                console.log(result.join(' '));
                    break;
            }
       // }

    }
    
}

solve(
    ['SWORD Shield Spear',
    'Buy Bag',
    'Trash Shield',
    'Repair Spear',
    'Upgrade Bag-Kate',
    'Fight!']
    );