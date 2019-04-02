function time(input){
    let examHours = Number(input[0]);
    let examMinutes = Number(input[1]);
    let arrivalHours = Number(input[2]);
    let arrivalMinutes = Number(input[3]);

    let examInMinutes = examHours * 60 + examMinutes
    let arrivalInMinutes = arrivalHours * 60 + arrivalMinutes

    let finalMinutes = Math.abs(examInMinutes - arrivalInMinutes);
    let hours = Math.floor(arrivalInMinutes / 60);
    let minutes = finalMinutes % 60;


    if (arrivalInMinutes > examInMinutes) {
        console.log("Late");
        if (hours == 0) {
            console.log(`${minutes} after the start`)
        }else if (hours > 0 && minutes < 10) {
            console.log(`${hours}:0${minutes} hours after the start`)
        }else if (hours > 0 && minutes >= 10) {
            console.log(`${hours}:${minutes} hours after the start`)
        }
    } else if ((examInMinutes == arrivalInMinutes) || (arrivalInMinutes >= examInMinutes - 30 && arrivalInMinutes < examInMinutes )) {
        console.log("On time")
        if(arrivalInMinutes >= examInMinutes - 30 && arrivalInMinutes < examInMinutes) {
            console.log(`${minutes} minutes before the start`)
        }
    } else {
        console.log("Early");
        if (hours == 0) {
            console.log(`${minutes} before the start`)
        }else if (hours > 0 && minutes < 10) {
            console.log(`${hours}:0${minutes} hours before the start`)
        }else if (hours > 0 && minutes >= 10) {
            console.log(`${hours}:${minutes} hours before the start`)
        }
    }
}
time([11,30,10,55]);