function solve(str) {
    let list = [];
    let sum = 0;
    str.forEach(el => {
        let town = el.split('|');
        list.push(town[1].trim());
        sum += Number(town[2].trim());   
    });
    console.log(list.join(', '));
    console.log(sum);
}

solve( [
    '| Sofia           | 300',
    '| Veliko Tarnovo  | 500',
    '| Yambol          | 275'
]);
