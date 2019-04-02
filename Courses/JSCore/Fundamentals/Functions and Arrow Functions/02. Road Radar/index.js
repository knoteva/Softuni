function getLimit(input){
    //console.log(input);
    let [speed, zone] = input;
    //console.log("SPEED: " + speed);
    //console.log("ZONE: " + zone);
    let limit = 0;
    switch(zone) {
        case "motorway":
            limit = +130;
            break;
        case "interstate":
            limit = +90;
            break;
            case "city":
            limit = +50;
            break;
        case "residential":
            limit = +20;
            break;
        deafult:
            break;
    }
    if(+speed - +limit <= +0){
        console.log("");
    } else if(+speed - +limit <= +20){
        console.log("speeding");
    }else if(+speed - +limit <= +40){
        console.log("excessive speeding");
    } else {
        console.log("reckless driving");

    }

}
//getLimit([200, 'motorway'])