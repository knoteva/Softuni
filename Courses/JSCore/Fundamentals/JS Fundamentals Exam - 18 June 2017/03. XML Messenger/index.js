function solve(input){
    input = input.replace(/\n/g, " ");

    let regex = /<message (to|from)="(.*?)" (to|from)="(.*?)">(.*?)<\/message>/g;
    let regex1 = />(.*?)<\/message>/g;
    let matches = regex.exec(input);
    let matches1 = regex1.exec(input)
   // console.log(matches);
   let result = "";
   let from = "";
   let to = "";
   if (matches1 && !matches) {
    console.log("Missing attributes");
    return;
    }
   if (!matches) {
    console.log("Invalid message format");
    return;
}
    if(matches){
        let mess = matches[5]
        if(matches[1].toLowerCase() == 'from'){
            from = matches[2];
            to = matches[4];
        } else {
            from = matches[4];
            to = matches[2];
        }
      
       
        result = `<article>\n  <div>From: <span class="sender">${from}</span></div>\n  <div>To: <span class="recipient">${to}</span></div>\n  <div>\n    <p>${mess}</p>\n  </div>\n</article>`
        console.log(result);
    }
    


}
solve(
    
        "<message to=\"Bob\" from=\"Alice\" timestamp=\"1497254114\">Same old, same old\nLet\'s go out for a beer</message>"  
   );