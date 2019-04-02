function quadratic(a, b, c) {
	var d = Math.sqrt(b * b - 4 * a * c);
	var x1 = 0;
	var x2 = 0;
	if(d > 0){
		x1 = (-b - d) / (2 * a);
		x2 = (-b + d) / (2 * a);
		console.log("x1 = " + x1);
		console.log("x2 = " + x2);
	} else if (d == 0) {
		x1 = -b / (2 * a)
        console.log("x = "  + x1);
    } else {
    	console.log('No real roots');
    }
}
quadratic(2, 5, -3);
quadratic(2, -4, 2);
quadratic(4, 2, 1);