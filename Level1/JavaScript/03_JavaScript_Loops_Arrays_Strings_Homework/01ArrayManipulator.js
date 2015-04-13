function print(input) {
    var nums = input.filter(function(a) {
        return !isNaN(a);
    });

    var minNum = Math.min.apply(null, nums),
    maxNum = Math.max.apply(null, nums);
    var num;
    var count = 1;
    var maxCount = 0;

       nums.sort(function(x, y) {
	    return x < y;
    });

   for (var i = 0; i < nums.length; i++) {
   		if (i === nums.length - 1){
   			break;
   		}
   	    if (nums[i] === nums[i + 1]) {
   	    	count++;
   	    	if (count >= maxCount) {
   	    		num = nums[i];
   	    		maxCount = count;
   	    	}
   	    }else {
   	   		count = 1;
   	    }
   };

    console.log("Min number: " + minNum);
	  console.log("Max number: " + maxNum);
	  console.log("Most frequent number: " + num);
    console.log(nums);
}

print(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount: 10 }, [10, 20, 30, 40]]);