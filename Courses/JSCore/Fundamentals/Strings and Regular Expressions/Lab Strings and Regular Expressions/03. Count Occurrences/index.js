// function solve(word, arr) {
//     let result = arr.split(word).length - 1
//         console.log(result);
 
   

// }
// solve('Ma', 
// 'Marine mammal training is the training and caring for marine life such as, dolphins, killer whales, sea lions, walruses, and other marine mammals. It is also a duty of the trainer to do mental and physical exercises to keep the animal healthy and happy.')

function countOccurances(key, text) {
    let count = 0;
    let indexOfKey = text.indexOf(key);

    while (indexOfKey >= 0) {
        count++;
        indexOfKey = text.indexOf(key, indexOfKey + 1);   
    }

    return count;
}

console.log(countOccurances('haha', 'hahaha'));