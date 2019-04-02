function print(input) {
    var nums = input.map(function(a) {

    	if (a >= 0 && a <= 400) {
    		 return a - a * 20 / 100;
    	};  

    }).filter(function (x) {
        return x;
    });
    
    nums.sort(function (x, y) {
        return x > y;
    });

    console.log(nums);
}
print([200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1]);