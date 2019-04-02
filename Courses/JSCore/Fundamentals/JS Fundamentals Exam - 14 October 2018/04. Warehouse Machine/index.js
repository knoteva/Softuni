function solve(str) {
    for(let line of str){
        let [command, brand, name, date, quantity] = line.split(', ');
        while(command !== "REPORT" || command !== "INSPECTION"){
            if(){
                
            }
        }
        console.log(command)
        if(command === "REPORT"){

        }
        if(command === "INSPECTION"){

        }
    }
      

}

solve([
    "IN, Batdorf & Bronson, Espresso, 2025-05-25, 20",
    "IN, Folgers, Black Silk, 2023-03-01, 14",
    "IN, Lavazza, Crema e Gusto, 2023-05-01, 5",
    "IN, Lavazza, Crema e Gusto, 2023-05-02, 5",
    "IN, Folgers, Black Silk, 2022-01-01, 10",
    "IN, Lavazza, Intenso, 2022-07-19, 20",
    "OUT, Dallmayr, Espresso, 2022-07-19, 5",
    "OUT, Dallmayr, Crema, 2022-07-19, 5",
    "OUT, Lavazza, Crema e Gusto, 2020-01-28, 2",
    "REPORT",
    "INSPECTION",
  ])
