function solve(input){

    let numbers = [];
    let result = "";
    for(let el of input){
        //console.log(el);
        if(typeof el === 'number'){
            numbers.push(el);
        }
        if(el === '+'){
            if(numbers.length >= 2){
                result = numbers.pop();
                result += +numbers.pop();
                numbers.push(result);
            } else {
                result = "Error: not enough operands!"
            }

        } else if(el === '-'){
            if(numbers.length >= 2){
                result = numbers.pop();
                result = +numbers.pop() - +result;
                numbers.push(result);
            } else {
                result = "Error: not enough operands!"
            }

        } else if(el === '*'){
            if(numbers.length >= 2){
                result = numbers.pop();
                result *= +numbers.pop();
                numbers.push(result);
            } else {
                result = "Error: not enough operands!"
            }

        } else if(el === '/'){
            if(numbers.length >= 2){
                result = numbers.pop();
                result = +numbers.pop() / +result;
                numbers.push(result);
            } else {
                result = "Error: not enough operands!"
            }

        }
    }
    if(numbers.length <= 1){
        console.log(result);
    } else {
        result = 'Error: too many operands!';
        console.log(result);
    }
    
}
solve(
    [
        '+']
       
   );