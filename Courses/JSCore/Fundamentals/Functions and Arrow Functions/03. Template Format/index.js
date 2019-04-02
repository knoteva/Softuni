function template(input){

console.log(`<?xml version="1.0" encoding="UTF-8"?>
<quiz>`)
for(let i = 0; i < input.length; i+=2){
console.log(`<question>\n ${input[i]}\n</question>\n<answer>\n ${input[i+1]}\n</answer>`);

}
//   <question>
//     ${input[0]}
//   </question>
//   <answer>
//     ${input[1]}
//   </answer>
console.log(`</quiz>`)
}

// template(["Dry ice is a frozen form of which gas?",
// "Carbon Dioxide",
// "What is the brightest star in the night sky?",
// "Sirius"]
// );