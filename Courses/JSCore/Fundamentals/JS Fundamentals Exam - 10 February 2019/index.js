function solve(examPoints, homePoints, toTalhomePoints){
    if(examPoints == 400){      
        console.log(6.00.toFixed(2));
    } else {
        let homeBonus = homePoints / toTalhomePoints * 10;
        let totalPoints = (examPoints * 90) / 400 + homeBonus;
        let grade = 3 + 2 * (totalPoints - 100 / 5) /  (100 / 2);
        if(grade < 3.00){
            grade = 2;          
        }
        if(grade > 6.00){
            grade = 6;             
        }
        console.log(grade.toFixed(2));
    }
}
solve(300, 10, 10);