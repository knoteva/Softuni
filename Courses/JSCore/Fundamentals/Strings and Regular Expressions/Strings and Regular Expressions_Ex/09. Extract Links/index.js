function solve(arr) {
    let regex = /www\.[a-zA-Z0-9-]+(\.[a-z]+)+/gm
    let str = arr.join(' ');
    let matches = str.match(regex);
    if(matches){
        console.log(matches.join('\n'));

    }
    
    
}
//  solve(['Join WebStars now for free, at www.web-stars.com', 
//  'You can also support our partners:', 
//  'Internet - www.internet.com', 
//  'WebSpiders - www.webspiders101.com', 
//  'Sentinel - www.sentinel.-ko'] 
//  );