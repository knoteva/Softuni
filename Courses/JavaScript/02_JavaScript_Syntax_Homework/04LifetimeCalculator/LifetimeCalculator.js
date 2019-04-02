function calcSupply(age, maxAge, food, foodPerDay) {
var amount = (maxAge - age) * 365 * foodPerDay;
return amount + "kg of " + food + " would be enough until I am " + maxAge + " years old.";
}
console.log(calcSupply(38, 118, "chocolate", 0.5) + '\n' + calcSupply(20, 87, "fruits", 2) + '\n' + calcSupply(16, 102, "nuts", 1.1));



