function solve(input){

    let html = "<table>\n <tr><th>name</th><th>score</th></tr>\n";
    for (let line of input) {
        let arr = JSON.parse(line);
        html += `  <tr><td>${arr['name']}` + `</td><td>${arr['score']}</td></tr>\n`;
    }
    html += "</table>";
   console.log(html);
   
 
}

solve(['{"name":"Pesho","score":479}','{"name":"Gosho","score":205}'])

