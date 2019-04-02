function average(number){
    let len = number.toString().length;
   
    sum = number
        .toString()
        .split('')
        .map(Number)
        .reduce(function (a, b) {
            return a + b;
        }, 0);
    while(+sum / +len <= 5){
        //console.log(+sum / +len);
        number += "9";
        sum += +9;
        len++;
    }
    console.log(number);
}

 average(5018);