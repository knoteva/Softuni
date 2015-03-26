function findYoungestPerson(array) {
    var name = [];
    var younger = Number.MAX_VALUE;
    //console.log(younger);

    array.forEach(function (x) {
        if (x["hasSmartphone"] && x["age"] < younger) {
            name = x["firstname"] + " " + x["lastname"];
            younger = x["age"];
        }
    });
   
 console.log("The youngest person is " + name);
}

var people = [
    { firstname: 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname: 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname: 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname: 'Baba', lastname: 'Ginka', age: 15, hasSmartphone: false }
];


findYoungestPerson(people);