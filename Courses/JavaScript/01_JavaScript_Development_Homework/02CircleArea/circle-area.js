function circleArea(r) {
	var area = Math.PI * Math.pow(r, 2);
	return area;
}

document.getElementById("first").innerHTML = circleArea(7);
document.getElementById("second").innerHTML = circleArea(1.5);
document.getElementById("third").innerHTML = circleArea(20);