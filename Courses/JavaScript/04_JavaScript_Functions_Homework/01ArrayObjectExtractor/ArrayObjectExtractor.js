function extractObjects(array) {
    var output = [];
    
    array.forEach(function (x) {
        if (typeof x === "object" && !Array.isArray(x)) {
            output.push(x);
        }
    });
    console.log(output);
}

var input = [
    "Pesho",
    4,
    4.21,   
    { name: 'Valyo', age: 16 },
    { type: 'fish', model: 'zlatna ribka' },
    [1, 2, 3],
    "Gosho",
    { name: 'Penka', height: 1.65 }
];

extractObjects(input);

