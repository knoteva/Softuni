function solve(input) {
    let result = `<table>`
  input.forEach(line => {
      let el = JSON.parse(line);
      result += ` \n <tr>\n  <td>${Object.values(el)[0]}</td>\n  <td>${Object.values(el)[1]}</td>\n  <td>${Object.values(el)[2]}</td>\n </tr>`
      //console.log(Object.values(el));
  });
  result += `\n</table>`
  console.log(result);
}
solve([
'{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}'
])