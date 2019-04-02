function solve(input){
let lengthReg = /32656 19759 32763\s+0\s+([0-9])/g;
let length;
let firstPart;
let kod;
let line = input.join(' ');

//let matches = lengthReg.exec(input);
//console.log(input)
////for(let line of input){
    let matches = line.match(lengthReg);
    //console.log(line);
    firstPart = matches.slice(-1).pop()
    length = firstPart.slice(-1);
    kod = line.split(' ')
    
    line = line.replace(firstPart + " 0 ","");
    //line = line.replace(/0 /g,"");
    line = line.replace('32656 19759 32763' ,"");
    line = line.replace(/(?<!\S)\d(?![^\s.,?!])/g,"").trim();
    //console.log(firstPart);
    //console.log(line);
    //console.log(line.length);
    line = line.split(' ');
    let res = "";
    for(let el of line){
        res += String.fromCharCode(el);
    }
    //console.log(l);
    
//}
console.log(line.join(' ').split(/\s+/));

}

solve(
[
    '32656 19759 32763 0 5 0 80 101 115 104 111 0 0 0 0 0 0 0 0 0 0 0',
    '0 32656 19759 32763 0 7 0 83 111 102 116 117 110 105 0 0 0 0 0 0'
]);