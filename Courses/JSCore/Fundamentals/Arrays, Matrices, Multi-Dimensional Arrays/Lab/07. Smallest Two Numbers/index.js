function smallestTwo(arr) {
    return arr.sort((a, b) => a-b).slice(0,2).join(' ');
}
console.log(smallestTwo([3, 0, 10, 4, 7, 3]));

//return arr[0] + " " + arr[1];